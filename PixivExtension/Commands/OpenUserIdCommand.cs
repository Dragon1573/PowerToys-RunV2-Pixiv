// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.CommandPalette.Extensions.Toolkit;

namespace PixivExtension;
public sealed partial class OpenUserIdCommand : InvokableCommand {
    public CommandResult Result { get; set; } = CommandResult.Hide();
    private readonly string _user;

    public OpenUserIdCommand(string user) {
        _user = user;
        Name = $"打开用户主页：{user}";
        Icon = IconHelpers.FromRelativePath("Assets/Pixiv_Logo.png");
    }

    public override CommandResult Invoke() {
        ShellHelpers.OpenInShell($"https://www.pixiv.net/users/{_user}");
        return Result;
    }
}