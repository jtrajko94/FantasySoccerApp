using System.ComponentModel;
using System.Runtime.CompilerServices;
using FantasySoccerApp.AppLayout.Models;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace FantasySoccerApp.AppLayout.ViewModels
{
    [Preserve(AllMembers = true)]
    [QueryProperty("QueryData", "data1")]
    public class TemplatePageViewModel : INotifyPropertyChanged
    {
        #region Fields

        /// <summary>
        /// Gets or sets the selected category.
        /// </summary>
        private Category selectedCategory;

        #endregion

        #region event
        /// <summary>
        /// The declaration of the PropertyChanged event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the selected category.
        /// </summary>
        public Category SelectedCategory
        {
            get => this.selectedCategory;
            set
            {
                if (TemplatePageViewModel.Equals(value, this.selectedCategory))
                {
                    return;
                }

                this.selectedCategory = value;
                this.OnPropertyChanged();
            }
        }
        #endregion

        #region Methods

        /// <summary>
        /// The PropertyChanged event occurs when changing the value of property.
        /// </summary>
        /// <param name="propertyName">Property name</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}

