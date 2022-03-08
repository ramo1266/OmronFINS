Imports System.Threading

Public Class MainForm

    Private MainFormUpdateThread As Thread
    Private PrevReadAccessLevel As Integer = -1
    Private UpdateStackLightControlThread As Thread


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        MainScreen = Me
        Main.startup()
        MachineSettingScreen = New MachineSetting
        RecipeSettingScreen = New RecipeSetting
        IOControlScreen = New IOControl
        AboutScreen = New About

        PreRunScreen = New PreRun
        RunScreen = New Run



        LogInMenuBarScreen = New LoginMenuBar()
        NonRunningMenuBarScreen = New NonRunningMenuBar()
        RecipeMenuBarScreen = New RecipeMenuBar()
        RunningMenuBarScreen = New RunningMenuBar



        MachineSettingScreen.TopLevel = False
        IOControlScreen.TopLevel = False
        RecipeSettingScreen.TopLevel = False
        LogInMenuBarScreen.TopLevel = False
        NonRunningMenuBarScreen.TopLevel = False
        AboutScreen.TopLevel = False
        RecipeMenuBarScreen.TopLevel = False
        PreRunScreen.TopLevel = False
        RunScreen.TopLevel = False
        RunningMenuBarScreen.TopLevel = False



        Window_Panel.Controls.Add(MachineSettingScreen)
        Window_Panel.Controls.Add(IOControlScreen)
        Window_Panel.Controls.Add(RecipeSettingScreen)

        Window_Panel.Controls.Add(AboutScreen)
        Window_Panel.Controls.Add(PreRunScreen)
        Window_Panel.Controls.Add(RunScreen)


        Menu_Panel.Controls.Add(LogInMenuBarScreen)
        Menu_Panel.Controls.Add(NonRunningMenuBarScreen)
        Menu_Panel.Controls.Add(RecipeMenuBarScreen)
        Menu_Panel.Controls.Add(RunningMenuBarScreen)


        System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False

        ShowLogInMenuBarScreen()
        ShowAboutScreen()

    End Sub





    Public Sub ShowNonRunningMenuBar()
        HideAllMenuBar()
        NonRunningMenuBarScreen.Show()
    End Sub

    Public Sub ShowLoginMenuBar()

        HideAllMenuBar()
        LogInMenuBarScreen.Show()

    End Sub

    Public Sub ShowRecipeMenuBar()

        HideAllMenuBar()
        RecipeMenuBarScreen.Show()

    End Sub

    Public Sub ShowRunningMenuBar()
        HideAllMenuBar()
        RunningMenuBarScreen.Show()
    End Sub

    Public Sub ShowInitialThreadingScreen()
        HideAllScreens()

    End Sub
    Public Sub ShowIOControlScreen()
        HideAllScreens()
        IOControlScreen.Show()

    End Sub

    Public Sub ShowMachineSettingScreen()
        HideAllScreens()
        MachineSettingScreen.Show()

    End Sub

    Public Sub ShowRecipeScreen()
        HideAllScreens()
        HideAllMenuBar()
        RecipeMenuBarScreen.Show()
        RecipeSettingScreen.Show()

    End Sub



    Public Sub ShowAboutScreen()
        HideAllScreens()
        AboutScreen.Show()

    End Sub

    Public Sub ShowLogInMenuBarScreen()
        HideAllScreens()
        LogInMenuBarScreen.Show()

    End Sub


    Public Sub ShowPreRunScreen()
        HideAllScreens()

        PreRunScreen.Show()


    End Sub

    Public Sub ShowRunScreen()
        HideAllScreens()

        RunScreen.Show()


    End Sub

    Public Sub HideAllMenuBar()
        LogInMenuBarScreen.Hide()
        NonRunningMenuBarScreen.Hide()
        RecipeMenuBarScreen.Hide()
        RunningMenuBarScreen.Hide()
    End Sub

    Public Sub HideAllScreens()
        IOControlScreen.Hide()
        MachineSettingScreen.Hide()
        RecipeSettingScreen.Hide()
        AboutScreen.Hide()
        PreRunScreen.Hide()
        RunScreen.Hide()


    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ControlBox = False
        Me.WindowState = FormWindowState.Maximized
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Fixed3D
    End Sub

    Private Sub Menu_Panel_Paint(sender As Object, e As PaintEventArgs) Handles Menu_Panel.Paint


    End Sub

    Private Sub MainForm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.Invalidate()
    End Sub
End Class
