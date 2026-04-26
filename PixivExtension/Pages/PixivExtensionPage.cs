// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.CommandPalette.Extensions;
using Microsoft.CommandPalette.Extensions.Toolkit;
using System;
using System.Collections.Generic;

namespace PixivExtension;

internal sealed partial class PixivExtensionPage : DynamicListPage {
    private List<ListItem> _listItems;
    private readonly ListItem _homepageItem = new(new OpenUrlCommand("https://www.pixiv.net/")) {
        Icon = IconHelpers.FromRelativePath("Assets\\Pixiv_Logo.png"),
        Title = "Pixiv",
        Subtitle = "打开 Pixiv 首页",
    };

    public PixivExtensionPage() {
        Icon = IconHelpers.FromRelativePath("Assets\\Pixiv_Logo.png");
        Title = "Pixiv";
        Name = "打开";
        PlaceholderText = "快捷搜索 Artworks ID, User ID 或画师名...";
        _listItems = [_homepageItem];
    }

    private List<ListItem> Query(string searchText) {
        ArgumentNullException.ThrowIfNull(searchText);

        var results = new List<ListItem>();

        if (string.IsNullOrEmpty(searchText)) {
            results.Add(_homepageItem);
        } else {
            if (long.TryParse(searchText, out _)) {
                results.Add(new(new OpenArtworksIdCommand(searchText)) {
                    Icon = IconHelpers.FromRelativePath("Assets\\Pixiv_Logo.png"),
                    Title = $"打开插画ID：{searchText}",
                });
                results.Add(new(new OpenUserIdCommand(searchText)) {
                    Icon = IconHelpers.FromRelativePath("Assets\\Pixiv_Logo.png"),
                    Title = $"打开用户ID：{searchText}",
                });
            }

            results.Add(new(new SearchUsernameCommand(searchText)) {
                Icon = IconHelpers.FromRelativePath("Assets\\Pixiv_Logo.png"),
                Title = $"搜索画师：{searchText}",
            });
        }

        return results;
    }

    public override void UpdateSearchText(string oldSearch, string newSearch) {
        _listItems = [.. Query(newSearch)];
        RaiseItemsChanged(0);
    }

    public override IListItem[] GetItems() => [.. _listItems];
}
