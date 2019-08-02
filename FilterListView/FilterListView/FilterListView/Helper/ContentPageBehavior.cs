using Syncfusion.SfPullToRefresh.XForms;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Swiping
{
    public class ContentPageBehavior : Behavior<ContentPage>
    {
        private Syncfusion.ListView.XForms.SfListView firstLV;
        private Syncfusion.ListView.XForms.SfListView secondLV;
        private SfPullToRefresh sfPullToRefresh;
        private ListViewSwipingViewModel viewModel;
        Button button;
        protected override void OnAttachedTo(ContentPage bindable)
        {
            viewModel = new ListViewSwipingViewModel();
            firstLV = bindable.FindByName<Syncfusion.ListView.XForms.SfListView>("firstLV");
            secondLV= bindable.FindByName<Syncfusion.ListView.XForms.SfListView>("secondLV");
            button = bindable.FindByName<Button>("Reset");
            sfPullToRefresh = bindable.FindByName<SfPullToRefresh>("pullToRefresh");
            sfPullToRefresh.Refreshing += SfPullToRefresh_Refreshing;

            firstLV.BindingContext = viewModel;
            secondLV.BindingContext = viewModel;
            button.BindingContext = viewModel;
            firstLV.ItemsSource = viewModel.FirstLVCollection;
            firstLV.ItemsSource = viewModel.SecondLVCollection;

            viewModel.firstLV = firstLV;
            viewModel.secondLV = secondLV;

            base.OnAttachedTo(bindable);
        }

        private async void SfPullToRefresh_Refreshing(object sender, EventArgs e)
        {
            sfPullToRefresh.IsRefreshing = true;
            await Task.Delay(2000);
            viewModel.GenerateSource();
            sfPullToRefresh.IsRefreshing = false;
        }

        protected override void OnDetachingFrom(ContentPage bindable)
        {
            firstLV = null;
            secondLV = null;
            base.OnDetachingFrom(bindable);
        }
    }
}
