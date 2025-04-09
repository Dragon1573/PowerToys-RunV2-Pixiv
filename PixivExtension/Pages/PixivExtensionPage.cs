// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.CommandPalette.Extensions;
using Microsoft.CommandPalette.Extensions.Toolkit;

namespace PixivExtension;

internal sealed partial class PixivExtensionPage : ListPage {
    public PixivExtensionPage() {
        // 用于配置命令列表的图标
        Icon = IconHelpers.FromRelativePath("Assets\\Pixiv_Logo.png");
        // 配置具体的命令名称
        Title = "Pixiv";
        // 配置命令的描述，它会显示在 Command Palette 右下角
        Name = "打开";
    }

    public override IListItem[] GetItems() {
        return [
            // 打开 Pixiv 主页
            new ListItem(new OpenUrlCommand("https://www.pixiv.net/") {
                Result = CommandResult.Hide()
            }) {
                Icon = IconHelpers.FromRelativePath("Assets\\Pixiv_Logo.png"),
                Title = "打开 Pixiv 主页",
            },
            // TODO: 根据 Pixiv Artworks ID 打开对应的插画
            new ListItem(new OpenArtworksIdCommand("105503728")) {
                Icon = IconHelpers.FromRelativePath("Assets\\Pixiv_Logo.png"),
                Title = "打开指定的插画",
            },
            // TODO: 根据 Pixiv User ID 打开对应的用户
            new ListItem(new OpenUserIdCommand("3779820")) {
                Icon = IconHelpers.FromRelativePath("Assets\\Pixiv_Logo.png"),
                Title = "打开指定的用户",
            },
            // TODO: 搜索用户名
            new ListItem(new SearchUsernameCommand("はまけん。")) {
                Icon = IconHelpers.FromRelativePath("Assets\\Pixiv_Logo.png"),
                Title = "搜索指定的用户",
            },
        ];
    }
}
