// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.CommandPalette.Extensions;
using Microsoft.CommandPalette.Extensions.Toolkit;

namespace PixivExtension;

internal sealed partial class PixivExtensionPage : ListPage {
    public PixivExtensionPage() {
        // �������������б��ͼ��
        Icon = IconHelpers.FromRelativePath("Assets\\Pixiv_Logo.png");
        // ���þ������������
        Title = "Pixiv";
        // ���������������������ʾ�� Command Palette ���½�
        Name = "��";
    }

    public override IListItem[] GetItems() {
        return [
            // �� Pixiv ��ҳ
            new ListItem(new OpenUrlCommand("https://www.pixiv.net/") {
                Result = CommandResult.Hide()
            }) {
                Icon = IconHelpers.FromRelativePath("Assets\\Pixiv_Logo.png"),
                Title = "�� Pixiv ��ҳ",
            },
            // TODO: ���� Pixiv Artworks ID �򿪶�Ӧ�Ĳ廭
            new ListItem(new OpenArtworksIdCommand("105503728")) {
                Icon = IconHelpers.FromRelativePath("Assets\\Pixiv_Logo.png"),
                Title = "��ָ���Ĳ廭",
            },
            // TODO: ���� Pixiv User ID �򿪶�Ӧ���û�
            new ListItem(new OpenUserIdCommand("3779820")) {
                Icon = IconHelpers.FromRelativePath("Assets\\Pixiv_Logo.png"),
                Title = "��ָ�����û�",
            },
            // TODO: �����û���
            new ListItem(new SearchUsernameCommand("�Ϥޤ���")) {
                Icon = IconHelpers.FromRelativePath("Assets\\Pixiv_Logo.png"),
                Title = "����ָ�����û�",
            },
        ];
    }
}
