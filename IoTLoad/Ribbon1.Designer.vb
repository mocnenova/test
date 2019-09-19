Partial Class Ribbon1
    Inherits Microsoft.Office.Tools.Ribbon.RibbonBase

    <System.Diagnostics.DebuggerNonUserCode()>
    Public Sub New(ByVal container As System.ComponentModel.IContainer)
        MyClass.New()

        'Required for Windows.Forms Class Composition Designer support
        If (container IsNot Nothing) Then
            container.Add(Me)
        End If

    End Sub

    <System.Diagnostics.DebuggerNonUserCode()>
    Public Sub New()
        MyBase.New(Globals.Factory.GetRibbonFactory())

        'This call is required by the Component Designer.
        InitializeComponent()

    End Sub

    'Component overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Tab1 = Me.Factory.CreateRibbonTab
        Me.Group1 = Me.Factory.CreateRibbonGroup
        Me.btnSettings = Me.Factory.CreateRibbonButton
        Me.btnOrchInfo = Me.Factory.CreateRibbonButton
        Me.btnLoadData = Me.Factory.CreateRibbonButton
        Me.btnConfiguration = Me.Factory.CreateRibbonButton
        Me.btnHelp = Me.Factory.CreateRibbonButton
        Me.Tab1.SuspendLayout()
        Me.Group1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tab1
        '
        Me.Tab1.Groups.Add(Me.Group1)
        Me.Tab1.Label = "JDExcelerator"
        Me.Tab1.Name = "Tab1"
        '
        'Group1
        '
        Me.Group1.Items.Add(Me.btnSettings)
        Me.Group1.Items.Add(Me.btnOrchInfo)
        Me.Group1.Items.Add(Me.btnLoadData)
        Me.Group1.Items.Add(Me.btnConfiguration)
        Me.Group1.Items.Add(Me.btnHelp)
        Me.Group1.Label = "JDExcelerator"
        Me.Group1.Name = "Group1"
        '
        'btnSettings
        '
        Me.btnSettings.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.btnSettings.Image = Global.IoTLoad.My.Resources.Resources.connectionInfoSmall
        Me.btnSettings.Label = "Connection Info"
        Me.btnSettings.Name = "btnSettings"
        Me.btnSettings.ShowImage = True
        '
        'btnOrchInfo
        '
        Me.btnOrchInfo.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.btnOrchInfo.Image = Global.IoTLoad.My.Resources.Resources.OrchestrationSmall
        Me.btnOrchInfo.Label = "Select Orchestration"
        Me.btnOrchInfo.Name = "btnOrchInfo"
        Me.btnOrchInfo.ShowImage = True
        '
        'btnLoadData
        '
        Me.btnLoadData.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.btnLoadData.Image = Global.IoTLoad.My.Resources.Resources.LoadDataSmall
        Me.btnLoadData.Label = "Load Data"
        Me.btnLoadData.Name = "btnLoadData"
        Me.btnLoadData.ShowImage = True
        '
        'btnConfiguration
        '
        Me.btnConfiguration.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.btnConfiguration.Image = Global.IoTLoad.My.Resources.Resources.settingSmall
        Me.btnConfiguration.Label = "General Settings"
        Me.btnConfiguration.Name = "btnConfiguration"
        Me.btnConfiguration.ShowImage = True
        '
        'btnHelp
        '
        Me.btnHelp.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.btnHelp.Image = Global.IoTLoad.My.Resources.Resources.infoSmall
        Me.btnHelp.Label = "About"
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.ShowImage = True
        '
        'Ribbon1
        '
        Me.Name = "Ribbon1"
        Me.RibbonType = "Microsoft.Excel.Workbook"
        Me.Tabs.Add(Me.Tab1)
        Me.Tab1.ResumeLayout(False)
        Me.Tab1.PerformLayout()
        Me.Group1.ResumeLayout(False)
        Me.Group1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Tab1 As Microsoft.Office.Tools.Ribbon.RibbonTab
    Friend WithEvents Group1 As Microsoft.Office.Tools.Ribbon.RibbonGroup
    Friend WithEvents btnSettings As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents btnOrchInfo As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents btnConfiguration As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents btnHelp As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents btnLoadData As Microsoft.Office.Tools.Ribbon.RibbonButton
End Class

Partial Class ThisRibbonCollection

    <System.Diagnostics.DebuggerNonUserCode()> _
    Friend ReadOnly Property Ribbon1() As Ribbon1
        Get
            Return Me.GetRibbon(Of Ribbon1)()
        End Get
    End Property
End Class
