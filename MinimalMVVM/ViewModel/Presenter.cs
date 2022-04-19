using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MinimalMVVM.Model;

namespace MinimalMVVM.ViewModel
{
    public class Presenter : ObservableObject
    {
        private TextConverter _textConverter = new TextConverter(s => s.ToUpper());
        private string _someText;
        private readonly ObservableCollection<string> _upperHistory = new ObservableCollection<string>();
        private readonly ObservableCollection<string> _lowerHistory = new ObservableCollection<string>();

        public string SomeText
        {
            get { return _someText; }
            set
            {
                _someText = value;
                RaisePropertyChangedEvent("SomeText");
            }
        }

        public IEnumerable<string> UpperHistory
        {
            get { return _upperHistory; }
        }

        public IEnumerable<string> LowerHistory
        {
            get { return _lowerHistory; }
        }

        public ICommand ConvertUpperTextCommand
        {
            get { return new DelegateCommand(ConvertText); }
        }

        public ICommand ConvertLowerTextCommand
        {
            get {
                _textConverter = new TextConverter(s => s.Trim().ToLower());
                return new DelegateCommand(ConvertText); }
        }

        private void ConvertText()
        {
            string text = _textConverter.ConvertText(SomeText);
            AddToHistory(text, text.ToUpper() == text);
            SomeText = String.Empty;
        }

        private void AddToHistory(string item, bool upper)
        {
            if (upper &&!_upperHistory.Contains(item))
                    _upperHistory.Add(item);
            else  if(!_lowerHistory.Contains(item))
                _lowerHistory.Add(item);
        }
    }
}
