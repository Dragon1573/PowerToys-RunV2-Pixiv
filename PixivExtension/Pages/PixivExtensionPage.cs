// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.CommandPalette.Extensions;
using Microsoft.CommandPalette.Extensions.Toolkit;
using System;
using System.Collections.Generic;

namespace PixivExtension;

internal sealed partial class PixivExtensionPage : DynamicListPage {
    private List<ListItem> listItems;
    private readonly ListItem homepageItem = new(new OpenUrlCommand("https://www.pixiv.net/")) {
        // 配置命令的图标
        Icon = IconHelpers.FromRelativePath("Assets\\Pixiv_Logo.png"),
        // 配置命令的名称
        Title = "Pixiv",
        // 配置命令的描述，它会显示在 Command Palette 右下角
        Subtitle = "打开 Pixiv 首页",
    };

    public PixivExtensionPage() {
        // 用于配置命令列表的图标
        Icon = IconHelpers.FromRelativePath("Assets\\Pixiv_Logo.png");
        // 配置具体的命令名称
        Title = "Pixiv";
        // 配置命令的描述，它会显示在 Command Palette 右下角
        Name = "打开";
        // 配置命令的占位符文本，它会显示在 Command Palette 的输入框中
        PlaceholderText = "快捷搜索 Artworks ID, User ID 或画师名...";
        listItems = [homepageItem];
    }

    public List<ListItem> Query(string searchText) {
        ArgumentNullException.ThrowIfNull(searchText);

        var results = new List<ListItem>();

        // 如果搜索文本为空，则返回空列表
        if (string.IsNullOrEmpty(searchText)) {
            results.Add(homepageItem);
        } else {
            // 判断是否为数字，只有纯数字的字符串才会被认为是 ID
            if (long.TryParse(searchText, out long _)) {
                // 添加作品链接
                results.Add(new (new OpenArtworksIdCommand(searchText)) {
                    Icon=IconHelpers.FromRelativePath("Assets\\Pixiv_Logo.png"),
                    Title=$"打开插画ID：{searchText}"
                });

                // 添加用户链接
                results.Add(new (new OpenUserIdCommand(searchText)) {
                    Icon=IconHelpers.FromRelativePath("Assets\\Pixiv_Logo.png"),
                    Title= $"打开用户ID：{searchText}"
                });
            }
            // 添加搜索画师链接
            results.Add(new (new SearchUsernameCommand(searchText)) { 
                Icon=IconHelpers.FromRelativePath("Assets\\Pixiv_Logo.png"),
                Title=$"搜索画师：{searchText}"
            });
        }

        return results;
    }

    /// <summary>
    /// 更新搜索文本
    /// </summary>
    /// <param name="oldSearch">更新前的文本</param>
    /// <param name="newSearch">更新后的文本</param>
    public override void UpdateSearchText(string oldSearch, string newSearch) {
        // 执行搜索
        listItems = [.. Query(newSearch)];
        // 如果搜索文本没有变化，则不需要更新
        RaiseItemsChanged(0);
    }

    /// <summary>
    /// 获取当前页面的命令列表
    /// </summary>
    public override IListItem[] GetItems() => [.. listItems];
}
