// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.CommandPalette.Extensions;
using Microsoft.CommandPalette.Extensions.Toolkit;

namespace PixivExtension;

public partial class PixivExtensionCommandsProvider : CommandProvider {
    private readonly ICommandItem[] _commands;

    public PixivExtensionCommandsProvider() {
        _commands = [
            new CommandItem(new PixivExtensionPage()) {
                Title = "Pixiv",
                Icon = IconHelpers.FromRelativePath("Assets\\Pixiv_Logo.png"),
                Subtitle = "全球知名的二次元插画平台",
            },
        ];
    }

    public override ICommandItem[] TopLevelCommands() {
        return _commands;
    }
}
