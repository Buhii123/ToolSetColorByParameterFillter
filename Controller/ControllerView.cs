using System;
using System.Collections.Generic;
using System.Linq;
using ToolSetColorByFillter.Views;
using ToolSetColorByFillter.Views.Base;
using Autodesk.Revit.DB;
using ToolSetColorByFillter.Models;
using ToolSetColorByFillter.Test;
using ToolSetColorByFillter.Lib;
using System.Windows;
using System.Windows.Controls;
using Autodesk.Revit.UI;
using System.Windows.Media;
using System.Windows.Forms;
using MessageBox = System.Windows.MessageBox;

namespace ToolSetColorByFillter.Controller
{
    public class ControllerView : ViewModelBase
    {
        private UIDocument _uidoc;
        private Document _doc;
        private MainWindows _mainview;
        private List<Parameter> _parameter;
        private List<GruopElement> _gruopElements;
        private List<ElementId> _elementIds;
        private FilteredElementCollector _collector;

        public MainWindows Mainview
        {
            get
            {
                if (_mainview == null)
                {
                    _mainview = new MainWindows() { DataContext = this };
                }
                return _mainview;
            }
            set
            {
                _mainview = value;
                OnPropertyChanged(nameof(Mainview));
            }
        }
        public List<Parameter> Parameters
        {
            get
            {
                return _parameter;
            }
            set
            {
                _parameter = value;
                OnPropertyChanged(nameof(Parameters));
            }
        }
        public List<GruopElement> GruopsElement
        {
            get
            {
                return _gruopElements;
            }
            set
            {
                _gruopElements = value;
                OnPropertyChanged(nameof(GruopsElement));
            }
        }
        public List<ElementId> ElementIds
        {
            get
            {
                return _elementIds;
            }
            set
            {
                _elementIds = value;
                OnPropertyChanged(nameof(ElementIds));
            }
        }
        public List<GetCategoryAndCount> Categories { get; set; } = new List<GetCategoryAndCount>();




        public ControllerView(Document doc, UIDocument uidoc)
        {
            this._doc = doc;
            this._uidoc = uidoc;

            TransactionMethod.TranTransactionRun(ResetTemporary, _doc, "UnHide");

            _collector = new FilteredElementCollector(doc, doc.ActiveView.Id);
            Categories = GetCategories();
            SelectionChangedCommand = new RelayCommand<object>(p => true, p => SelectChangeListView());
            SelectionChangedParameterCommand = new RelayCommand<object>(p => true, p => SelectChangeListViewParamter());
            ApplyCommand = new RelayCommand<object>(p => true, p => Apply());
            SelectionListElementsCommand = new RelayCommand<object>(p => true, p => SelectionListElements());
            HideElementCommand = new RelayCommand<object>(p => true, p => HideElement());
            UnHideCommand = new RelayCommand<object>(p => true, p => UnHideAll());
           
        }


        public RelayCommand<object> SelectionChangedCommand { get; set; }
        public RelayCommand<object> SelectionChangedParameterCommand { get; set; }
        public RelayCommand<object> SelectionListElementsCommand { get; set; }
        public RelayCommand<object> ApplyCommand { get; set; }
        public RelayCommand<object> HideElementCommand { get; set; }
        public RelayCommand<object> UnHideCommand { get; set; }

  

        private List<GetCategoryAndCount> GetCategories()
        {
            CategoryFilter categoriesFilter = new CategoryFilter(_collector);
            ElementFillter elementFilter = new ElementFillter(_collector);

            return categoriesFilter.ListItems()
                .Select(c => new GetCategoryAndCount(c, elementFilter.ListItems()))
                .ToList();

        }
        private void SelectChangeListView()
        {
            this._mainview.lvParameters.SelectedItem = null;
            var getcategory = this._mainview.lvCategory?.SelectedItem as GetCategoryAndCount;
            this._mainview.lvParameters.SelectedIndex = 0;
            Parameters = getcategory.ElementAll.GetParameters();

        }
        private void SelectChangeListViewParamter()
        {

            var parameters = new List<string>();
            var parameter = this._mainview.lvParameters?.SelectedItem as Parameter;
            var getcategory = this._mainview.lvCategory?.SelectedItem as GetCategoryAndCount;
            var random = new Random();
            var NewEleme = new List<GruopElement>();
            if (parameter != null)
            {

                parameters.AddRange(getcategory.ElementAll
                    .Select(el => el?
                    .LookupParameter(parameter.Definition.Name)?
                    .AsValueString())
                    .Where(p => p != null));
                var param = parameters.Distinct();
                NewEleme.AddRange(param
                        .Select(p => new GruopElement(p, parameter, getcategory.ElementAll, GetRandomColor(random))));
                GruopsElement = NewEleme;
            }


        }
        private void Apply()
        {
          
            using (TransactionGroup gr = new TransactionGroup(_doc, "Gruop Fillter"))
            {
                gr.Start();
                foreach (GruopElement grelemetn in GruopsElement)
                {
                    foreach (ElementByFilter el in grelemetn.Elements)
                    {
                        if (el != null) TransactionMethod.TranTransactionRun(SetColorElement, el, _doc, "Hide Element");
                      
                    }
                }
                gr.Assimilate();
            }
        }
        private void SelectionListElements()
        {
            var selected = this._mainview.lvElements?.SelectedItem as GruopElement;
            if (selected != null)
            {
                var elements = selected?.Elements?.Select(x => x?.Id).ToList();
                ElementIds = elements;
                using (Transaction tr = new Transaction(_doc, "Set Element ID"))
                {
                    tr.Start();
                    _uidoc.Selection.SetElementIds(elements);
                    _uidoc.ShowElements(elements);
                    tr.Commit();
                }
            }

        }
        public void HideElement()
        {
            if (ElementIds != null) TransactionMethod.TranTransactionRun(HideElementsTemporary, ElementIds, _doc, "Hide Element");
        }
        public void UnHideAll()
        {
            TransactionMethod.TranTransactionRun(ResetTemporary, _doc, "UnHide");
            
        }
        private System.Windows.Media.Color GetRandomColor(Random random)
        {
            byte[] colorBytes = new byte[3];
            random.NextBytes(colorBytes);
            return System.Windows.Media.Color.FromRgb(colorBytes[0], colorBytes[1], colorBytes[2]);

        }
       
        private void ResetTemporary() 
        {
            Autodesk.Revit.DB.View view = _doc.ActiveView;
           
            if (view.IsTemporaryHideIsolateActive())
            {
                TemporaryViewMode tempView = TemporaryViewMode.TemporaryHideIsolate;
                view.DisableTemporaryViewMode(tempView);
            }
         
        }
        private void HideElementsTemporary(List<ElementId> elementIds) 
        {
            _doc.ActiveView.IsolateElementsTemporary(elementIds);
        }
        private void SetColorElement(ElementByFilter e) 
        {
            _doc.ActiveView.SetElementOverrides(e.Id, new SetOptionColor(_doc, e.Color));
        }
    }
}
