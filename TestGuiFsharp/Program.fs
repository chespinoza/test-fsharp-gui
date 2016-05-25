// Hanging around with F# Gui basics
open System
open System.Windows
open System.Windows.Controls
open System.Windows.Markup

[<STAThread>]
[<EntryPoint>]
let main argv = 
    let mainWindow = Application.LoadComponent( new System.Uri("/TestGuiFsharp;component/MyApp.xaml", UriKind.Relative)) :?> Window
    let application = new Application()

    let button = mainWindow.FindName("MyButton1") :?> Button
    let textBox = mainWindow.FindName("MyTextBlock") :?> TextBlock
    let checkBox1 = mainWindow.FindName("checkBox1") :?> CheckBox
    let checkBox2 = mainWindow.FindName("checkBox2") :?> CheckBox

    button.Click
    |> Event.add(fun _ -> textBox.Text <- sprintf "Button Clicked!\nCheckBox1=%A\nCheckbox2=%A" checkBox1.IsChecked checkBox2.IsChecked)

    let comboBox = mainWindow.FindName("MyComboBox") :?> ComboBox
    comboBox.Items.Add("Item 1")
    comboBox.Items.Add("Item 2")

    comboBox.SelectionChanged
    |> Event.add(fun _ -> textBox.Text <- sprintf "%s Selected" (comboBox.SelectedValue.ToString()))

    application.Run(mainWindow)