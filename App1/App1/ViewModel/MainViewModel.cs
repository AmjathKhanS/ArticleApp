using App1.Model;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Threading.Tasks;

namespace App1.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    { 
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly ObservableCollection<ArticleModel> _articles= new ObservableCollection<ArticleModel> { };
        public ObservableCollection<ArticleModel> Articles => _articles; 
        private ArticleModel _selectedarticle;
        public ArticleModel SelectedArticle
        {
            get { return _selectedarticle; }
            set
            {
                if (_selectedarticle != value) 
                {
                    _selectedarticle = value;
                    OnPropertyChanged(nameof(SelectedArticle));
                }
            }
        }
        private int _loadcount = 10;
        public async void LoadDataAsync()
        {
            var newarticles = await ApiService.Instance.GetArticlesAsync(_loadcount, LabelConstants.APIURL);
            //Articles.Clear();
            foreach (var article in newarticles.results) 
            {
                Articles.Add(article);
            }
            OnPropertyChanged(nameof(Articles));
            
        }
        public async Task LoadMoreDataAsync()
        {
            _loadcount += 10;
            LoadDataAsync();
            return;
        }

        protected virtual void OnPropertyChanged(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

    }
}
