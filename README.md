# Filter listview items based on another listview selection

To filter the listview items based on the item selection in another listview, use the SfListView.DataSource.Filter property.

```
private void ItemTapped(Syncfusion.ListView.XForms.ItemTappedEventArgs e)
{
    tappedPinedInfo = e.ItemData as PinnedInfo;
    if (tappedPinedInfo.IsFavorite)
    {
        secondLV.DataSource.Filter = FilterDepartures;
        tappedPinedInfo.IsFavorite = false;
    }
    else
    {
        secondLV.DataSource.Filter = null;
        tappedPinedInfo.IsFavorite = true;
    }
    secondLV.DataSource.RefreshFilter();
}

private bool FilterDepartures(object obj)
{
    var departureInfo = obj as DepartureInfo;
    if (tappedPinedInfo == null)
        return true;

    if (departureInfo.Name.ToLower().Contains(tappedPinedInfo.Name.ToLower())
            || departureInfo.RouteName.ToLower().Contains(tappedPinedInfo.RouteName.ToLower()))
        return true;
    else
        return false;
}
```
## Swipe and move an item to another listview on siwpe item tapped action

By using swipe view action, you can move an item from one listview to another listview.

```
private void FavoriteTapped(object obj)
{
    var departureInfo = obj as DepartureInfo;
    var pinnedInfo = FirstLVCollection.Any(o => o.Name == departureInfo.Name) ? FirstLVCollection.First(o => o.Name == departureInfo.Name) : null;
    if (pinnedInfo == null)
    {
        FirstLVCollection.Add(new PinnedInfo() { Name = departureInfo.Name, RouteName = departureInfo.Name, Icon = departureInfo.Icon, IsFavorite = true });
    }
}
```

To know more about ListView, please refer our documentation [here](https://help.syncfusion.com/xamarin/sflistview/working-with-sflistview)