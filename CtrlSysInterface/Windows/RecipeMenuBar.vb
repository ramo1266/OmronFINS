Public Class RecipeMenuBar

    Private Sub RecipeAdd_Button_Click(sender As Object, e As EventArgs) Handles RecipeAdd_Button.Click



    End Sub

    Private Sub RecipeRemove_Button_Click(sender As Object, e As EventArgs) Handles RecipeRemove_Button.Click

    End Sub

    Private Sub RecipeCopy_Button_Click(sender As Object, e As EventArgs) Handles RecipeCopy_Button.Click

    End Sub

    Private Sub RecipeModify_Button_Click(sender As Object, e As EventArgs) Handles RecipeModify_Button.Click

    End Sub

    Private Sub RecipeTransfer_Button_Click(sender As Object, e As EventArgs) Handles RecipeTransfer_Button.Click



    End Sub

    Private Sub Done_Button_Click(sender As Object, e As EventArgs) Handles Done_Button.Click
        MainForm.ShowNonRunningMenuBar()
        MainForm.HideAllScreens()

    End Sub

    Private Sub RecipeMenuBar_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Me.Size = Main.MainScreen.Menu_Panel.Size


        Dim ButtonsCntrlList As New List(Of Control)
        ButtonsCntrlList.Add(RecipeAdd_Button)
        ButtonsCntrlList.Add(RecipeRemove_Button)
        ButtonsCntrlList.Add(RecipeCopy_Button)

        ButtonsCntrlList.Add(RecipeModify_Button)
        ButtonsCntrlList.Add(RecipeTransfer_Button)
        ButtonsCntrlList.Add(Done_Button)
        Dim i = 0
        For Each b In ButtonsCntrlList

            Dim Siz As Drawing.Size
            Siz.Width = (Me.Size.Width / (ButtonsCntrlList.Count))
            Siz.Height = Me.Size.Height
            b.Size = Siz

            Dim loc As Point
            loc.X = ((Me.Size.Width * i) / ButtonsCntrlList.Count)
            loc.Y = 0
            b.Location = loc
            i += 1
        Next

    End Sub
End Class