// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.CommandPalette.Extensions;
using Microsoft.CommandPalette.Extensions.Toolkit;

namespace PixivExtension;
public partial class SearchUsernameCommand : InvokableCommand {
    private readonly string _nickname;
    public CommandResult Result { get; set; } = CommandResult.Hide();

    public SearchUsernameCommand(string nickname) {
        _nickname = nickname;
        Icon = IconHelpers.FromRelativePath("Assets\\Pixiv_Logo.png");
        Name = $"打开";
    }

    public override ICommandResult Invoke() {
        ShellHelpers.OpenInShell($"https://www.pixiv.net/search/users?nick={_nickname}");
        return Result;
    }
}