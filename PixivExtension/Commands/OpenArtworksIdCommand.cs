// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.CommandPalette.Extensions.Toolkit;

namespace PixivExtension;

public sealed partial class OpenArtworksIdCommand : InvokableCommand {
    public CommandResult Result { get; set; } = CommandResult.Hide();
    private readonly string _artwork;

    public OpenArtworksIdCommand(string artwork) {
        _artwork = artwork;
        Name = $"打开插画编号：{artwork}";
        Icon = IconHelpers.FromRelativePath("Assets/Pixiv_Logo.png");
    }

    public override CommandResult Invoke() {
        ShellHelpers.OpenInShell($"https://www.pixiv.net/artworks/{_artwork}");
        return Result;
    }
}