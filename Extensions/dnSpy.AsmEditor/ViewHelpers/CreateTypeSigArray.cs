/*
    Copyright (C) 2014-2019 de4dot@gmail.com

    This file is part of dnSpy

    dnSpy is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    dnSpy is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with dnSpy.  If not, see <http://www.gnu.org/licenses/>.
*/

using System.Windows;
using dnlib.DotNet;
using dnSpy.AsmEditor.DnlibDialogs;

namespace dnSpy.AsmEditor.ViewHelpers {
	sealed class CreateTypeSigArray : ICreateTypeSigArray {
		readonly Window? ownerWindow;

		public CreateTypeSigArray()
			: this(null) {
		}

		public CreateTypeSigArray(Window? ownerWindow) => this.ownerWindow = ownerWindow;

		public TypeSig[]? Create(TypeSigCreatorOptions options, int? count, TypeSig[]? typeSigs) {
			var data = new CreateTypeSigArrayVM(options, count);
			if (typeSigs is not null)
				data.TypeSigCollection.AddRange(typeSigs);
			var win = new CreateTypeSigArrayDlg();
			win.DataContext = data;
			win.Owner = ownerWindow ?? Application.Current.MainWindow;
			if (win.ShowDialog() != true)
				return null;

			return data.TypeSigArray;
		}
	}
}
