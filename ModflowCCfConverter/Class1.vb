Imports Microsoft.VisualBasic

Public Class Class1


    Sub Main()
        Dim region As String
        Dim Num_files As Integer
        Dim num_ts As Integer

        region = "Downstream"

        Dim WellsFluxVals() As Object
        Dim DrainFluxVals() As Object
        Dim RiverFluxVals(,) As Object
        Dim GHeadsFluxVals() As Object
        Dim ETFluxVals() As Object
        Dim RechFluxVals() As Object
        Dim StorageVals() As Object

        Dim sr_1 As String
        Dim sr_2 As String
        Dim sr_3 As String
        Dim sr_4 As String
        Dim sr_5 As String
        Dim sr_6 As String
        Dim sr_7 As String
        Dim sr_8 As String
        Dim sr_9 As String
        Dim sr_10 As String
        Dim sr_11 As String
        Dim sr_12 As String
        Dim sr_13 As String
        Dim sr_14 As String
        Dim sr_15 As String
        Dim sr_16 As String
        Dim sr_17 As String
        Dim sr_18 As String
        Dim sr_19 As String
        Dim sr_20 As String
        Dim sr_21 As String
        Dim sr_22 As String
        Dim sr_23 As String
        Dim sr_24 As String
        Dim sr_25 As String
        Dim sr_26 As String
        Dim sr_27 As String
        Dim sr_28 As String
        Dim sr_29 As String
        Dim sr_30 As String
        Dim sr_31 As String
        Dim sr_32 As String
        Dim sr_33 As String
        Dim sr_34 As String
        Dim sr_35 As String
        Dim sr_36 As String
        Dim sr_37 As String
        Dim sr_38 As String
        Dim sr_39 As String
        Dim sr_40 As String
        Dim sr_41 As String
        Dim sr_42 As String
        Dim sr_43 As String
        Dim sr_44 As String
        Dim sr_45 As String
        Dim sr_46 As String
        Dim sr_47 As String
        Dim sr_48 As String
        Dim sr_49 As String
        Dim sr_50 As String
        Dim sr_51 As String
        Dim sr_52 As String
        Dim sr_53 As String
        Dim sr_54 As String
        Dim sr_55 As String
        Dim sr_56 As String
        Dim sr_57 As String
        Dim sr_58 As String
        Dim sr_59 As String
        Dim sr_60 As String
        Dim sr_61 As String
        Dim sr_62 As String
        Dim sr_63 As String
        Dim sr_64 As String
        Dim sr_65 As String
        Dim sr_66 As String
        Dim sr_67 As String
        Dim sr_68 As String
        Dim sr_69 As String
        Dim sr_70 As String
        Dim sr_71 As String
        Dim sr_72 As String
        Dim sr_73 As String
        Dim sr_74 As String
        Dim sr_75 As String
        Dim sr_76 As String
        Dim sr_77 As String
        Dim sr_78 As String
        Dim sr_79 As String
        Dim sr_80 As String
        Dim sr_81 As String
        Dim sr_82 As String
        Dim sr_83 As String
        Dim sr_84 As String
        Dim sr_85 As String
        Dim sr_86 As String
        Dim sr_87 As String
        Dim sr_88 As String

        Dim Nrow As Integer
        Dim Ncol As Integer
        Dim Nlay As Integer
        Dim Kstps As Integer
        Dim Cols As Integer
        Dim Rows As Integer
        Dim Layer As Integer
        Dim TimeStep As Integer
        Dim retval As Object
        Dim flowfilename As Object
        Dim trashlong As Integer, trashlong2 As Integer, trashsingle As Single
        Dim Ftext As New String(" ", 16), tmpText As New String(" ", 16)
        Dim i As Integer, x As Integer, y As Integer, CellID As Integer
        Dim ByteCount As Integer
        Dim totalperTS As Integer
        Dim TempVal As Single
        Dim layerFlux() As Object = Nothing
        Dim LayerID As Integer
        Dim NValsPerCell As Integer
        Dim SkipValues As Boolean
        Dim IsNewerMODFLOWOutput As Boolean = True
        Dim FileNameBase As String
        Dim BeginningTS As Integer
        Dim EndingTS As Integer
        Dim old_ts As Integer = 1
        Dim Scenario As Integer

        BeginningTS = 1
        If region = "Upstream" Then
            FileNameBase = "Remodel3"
            EndingTS = 448

            sr_1 = "S:\US_Scenarios\ScenarioModeling\10%_AltApp\Remodel3.ccf"
            sr_2 = "S:\US_Scenarios\ScenarioModeling\10%_FalFld\Remodel3.ccf"
            sr_3 = "S:\US_Scenarios\ScenarioModeling\10%_RedIrr\Remodel3.ccf"
            sr_4 = "S:\US_Scenarios\ScenarioModeling\10%Seep\Remodel3.ccf"
            sr_5 = "S:\US_Scenarios\ScenarioModeling\15%_AltApp\Remodel3.ccf"
            sr_6 = "S:\US_Scenarios\ScenarioModeling\15%_FalFld\Remodel3.ccf"
            sr_7 = "S:\US_Scenarios\ScenarioModeling\15%_RedIrr\Remodel3.ccf"
            sr_8 = "S:\US_Scenarios\ScenarioModeling\20%_AltApp\Remodel3.ccf"
            sr_9 = "S:\US_Scenarios\ScenarioModeling\20%_FalFld\Remodel3.ccf"
            sr_10 = "S:\US_Scenarios\ScenarioModeling\20%_RedIrr\Remodel3.ccf"
            sr_11 = "S:\US_Scenarios\ScenarioModeling\20%Seep\Remodel3.ccf"
            sr_12 = "S:\US_Scenarios\ScenarioModeling\25%_AltApp\Remodel3.ccf"
            sr_13 = "S:\US_Scenarios\ScenarioModeling\25%_FalFld\Remodel3.ccf"
            sr_14 = "S:\US_Scenarios\ScenarioModeling\25%_FalFld_20%_RedIrr\Remodel3.ccf"
            sr_15 = "S:\US_Scenarios\ScenarioModeling\25%_FalFld_20%_RedIrr_30%_Seep\Remodel3.ccf"
            sr_16 = "S:\US_Scenarios\ScenarioModeling\25%_FalFld_20%_RedIrr_30%_Seep_Reform_pET\Remodel3.ccf"
            sr_17 = "S:\US_Scenarios\ScenarioModeling\25%_FalFld_20%_RedIrr_50%_Seep\Remodel3.ccf"
            sr_18 = "S:\US_Scenarios\ScenarioModeling\25%_FalFld_20%_RedIrr_50%_Seep_Reform_pET\Remodel3.ccf"
            sr_19 = "S:\US_Scenarios\ScenarioModeling\25%_FalFld_20%_RedIrr_80%_Seep\Remodel3.ccf"
            sr_20 = "S:\US_Scenarios\ScenarioModeling\25%_FalFld_20%_RedIrr_80%_Seep_Reform_pET\Remodel3.ccf"
            sr_21 = "S:\US_Scenarios\ScenarioModeling\25%_FalFld_20%_RedIrr_Reform_pET\Remodel3.ccf"
            sr_22 = "S:\US_Scenarios\ScenarioModeling\25%_FalFld_25%_RedIrr\Remodel3.ccf"
            sr_23 = "S:\US_Scenarios\ScenarioModeling\25%_FalFld_25%_RedIrr_30%_Seep\Remodel3.ccf"
            sr_24 = "S:\US_Scenarios\ScenarioModeling\25%_FalFld_25%_RedIrr_30%_Seep_Reform_pET\Remodel3.ccf"
            sr_25 = "S:\US_Scenarios\ScenarioModeling\25%_FalFld_25%_RedIrr_50%_Seep\Remodel3.ccf"
            sr_26 = "S:\US_Scenarios\ScenarioModeling\25%_FalFld_25%_RedIrr_50%_Seep_Reform_pET\Remodel3.ccf"
            sr_27 = "S:\US_Scenarios\ScenarioModeling\25%_FalFld_25%_RedIrr_80%_Seep\Remodel3.ccf"
            sr_28 = "S:\US_Scenarios\ScenarioModeling\25%_FalFld_25%_RedIrr_80%_Seep_Reform_pET\Remodel3.ccf"
            sr_29 = "S:\US_Scenarios\ScenarioModeling\25%_FalFld_25%_RedIrr_Reform_pET\Remodel3.ccf"
            sr_30 = "S:\US_Scenarios\ScenarioModeling\25%_FalFld_30%_RedIrr\Remodel3.ccf"
            sr_31 = "S:\US_Scenarios\ScenarioModeling\25%_FalFld_30%_RedIrr_30%_Seep\Remodel3.ccf"
            sr_32 = "S:\US_Scenarios\ScenarioModeling\25%_FalFld_30%_RedIrr_30%_Seep_Reform_pET\Remodel3.ccf"
            sr_33 = "S:\US_Scenarios\ScenarioModeling\25%_FalFld_30%_RedIrr_50%_Seep\Remodel3.ccf"
            sr_34 = "S:\US_Scenarios\ScenarioModeling\25%_FalFld_30%_RedIrr_50%_Seep_Reform_pET\Remodel3.ccf"
            sr_35 = "S:\US_Scenarios\ScenarioModeling\25%_FalFld_30%_RedIrr_80%_Seep\Remodel3.ccf"
            sr_36 = "S:\US_Scenarios\ScenarioModeling\25%_FalFld_30%_RedIrr_80%_Seep_Reform_pET\Remodel3.ccf"
            sr_37 = "S:\US_Scenarios\ScenarioModeling\25%_FalFld_30%_RedIrr_Reform_pET\Remodel3.ccf"
            sr_38 = "S:\US_Scenarios\ScenarioModeling\25%_FalFld_35%_RedIrr\Remodel3.ccf"
            sr_39 = "S:\US_Scenarios\ScenarioModeling\25%_FalFld_35%_RedIrr_30%_Seep\Remodel3.ccf"
            sr_40 = "S:\US_Scenarios\ScenarioModeling\25%_FalFld_35%_RedIrr_30%_Seep_Reform_pET\Remodel3.ccf"
            sr_41 = "S:\US_Scenarios\ScenarioModeling\25%_FalFld_35%_RedIrr_50%_Seep\Remodel3.ccf"
            sr_42 = "S:\US_Scenarios\ScenarioModeling\25%_FalFld_35%_RedIrr_50%_Seep_Reform_pET\Remodel3.ccf"
            sr_43 = "S:\US_Scenarios\ScenarioModeling\25%_FalFld_35%_RedIrr_80%_Seep\Remodel3.ccf"
            sr_44 = "S:\US_Scenarios\ScenarioModeling\25%_FalFld_35%_RedIrr_80%_Seep_Reform_pET\Remodel3.ccf"
            sr_45 = "S:\US_Scenarios\ScenarioModeling\25%_FalFld_35%_RedIrr_Reform_pET\Remodel3.ccf"
            sr_46 = "S:\US_Scenarios\ScenarioModeling\25%_FalFld_40%_RedIrr\Remodel3.ccf"
            sr_47 = "S:\US_Scenarios\ScenarioModeling\25%_FalFld_40%_RedIrr_30%_Seep\Remodel3.ccf"
            sr_48 = "S:\US_Scenarios\ScenarioModeling\25%_FalFld_40%_RedIrr_30%_Seep_Reform_pET\Remodel3.ccf"
            sr_49 = "S:\US_Scenarios\ScenarioModeling\25%_FalFld_40%_RedIrr_50%_Seep\Remodel3.ccf"
            sr_50 = "S:\US_Scenarios\ScenarioModeling\25%_FalFld_40%_RedIrr_50%_Seep_Reform_pET\Remodel3.ccf"
            sr_51 = "S:\US_Scenarios\ScenarioModeling\25%_FalFld_40%_RedIrr_80%_Seep\Remodel3.ccf"
            sr_52 = "S:\US_Scenarios\ScenarioModeling\25%_FalFld_40%_RedIrr_80%_Seep_Reform_pET\Remodel3.ccf"
            sr_53 = "S:\US_Scenarios\ScenarioModeling\25%_FalFld_40%_RedIrr_Reform_pET\Remodel3.ccf"
            sr_54 = "S:\US_Scenarios\ScenarioModeling\25%_FalFld_45%_RedIrr\Remodel3.ccf"
            sr_55 = "S:\US_Scenarios\ScenarioModeling\25%_FalFld_45%_RedIrr_30%_Seep\Remodel3.ccf"
            sr_56 = "S:\US_Scenarios\ScenarioModeling\25%_FalFld_45%_RedIrr_30%_Seep_Reform_pET\Remodel3.ccf"
            sr_57 = "S:\US_Scenarios\ScenarioModeling\25%_FalFld_45%_RedIrr_50%_Seep\Remodel3.ccf"
            sr_58 = "S:\US_Scenarios\ScenarioModeling\25%_FalFld_45%_RedIrr_50%_Seep_Reform_pET\Remodel3.ccf"
            sr_59 = "S:\US_Scenarios\ScenarioModeling\25%_FalFld_45%_RedIrr_80%_Seep\Remodel3.ccf"
            sr_60 = "S:\US_Scenarios\ScenarioModeling\25%_FalFld_45%_RedIrr_80%_Seep_Reform_pET\Remodel3.ccf"
            sr_61 = "S:\US_Scenarios\ScenarioModeling\25%_FalFld_45%_RedIrr_Reform_pET\Remodel3.ccf"
            sr_62 = "S:\US_Scenarios\ScenarioModeling\25%_FalFld_50%_RedIrr\Remodel3.ccf"
            sr_63 = "S:\US_Scenarios\ScenarioModeling\25%_FalFld_50%_RedIrr_30%_Seep\Remodel3.ccf"
            sr_64 = "S:\US_Scenarios\ScenarioModeling\25%_FalFld_50%_RedIrr_30%_Seep_Reform_pET\Remodel3.ccf"
            sr_65 = "S:\US_Scenarios\ScenarioModeling\25%_FalFld_50%_RedIrr_50%_Seep\Remodel3.ccf"
            sr_66 = "S:\US_Scenarios\ScenarioModeling\25%_FalFld_50%_RedIrr_50%_Seep_Reform_pET\Remodel3.ccf"
            sr_67 = "S:\US_Scenarios\ScenarioModeling\25%_FalFld_50%_RedIrr_80%_Seep\Remodel3.ccf"
            sr_68 = "S:\US_Scenarios\ScenarioModeling\25%_FalFld_50%_RedIrr_80%_Seep_Reform_pET\Remodel3.ccf"
            sr_69 = "S:\US_Scenarios\ScenarioModeling\25%_FalFld_50%_RedIrr_Reform_pET\Remodel3.ccf"
            sr_70 = "S:\US_Scenarios\ScenarioModeling\25%_FalFld_Reform_pET\Remodel3.ccf"
            sr_71 = "S:\US_Scenarios\ScenarioModeling\25%_RedIrr\Remodel3.ccf"
            sr_72 = "S:\US_Scenarios\ScenarioModeling\30%_RedIrr\Remodel3.ccf"
            sr_73 = "S:\US_Scenarios\ScenarioModeling\30%_RedIrr_80%_Seep\Remodel3.ccf"
            sr_74 = "S:\US_Scenarios\ScenarioModeling\30%Seep\Remodel3.ccf"
            sr_75 = "S:\US_Scenarios\ScenarioModeling\35%_RedIrr\Remodel3.ccf"
            sr_76 = "S:\US_Scenarios\ScenarioModeling\40%_RedIrr\Remodel3.ccf"
            sr_77 = "S:\US_Scenarios\ScenarioModeling\40%Seep\Remodel3.ccf"
            sr_78 = "S:\US_Scenarios\ScenarioModeling\45%_RedIrr\Remodel3.ccf"
            sr_79 = "S:\US_Scenarios\ScenarioModeling\5%_AltApp\Remodel3.ccf"
            sr_80 = "S:\US_Scenarios\ScenarioModeling\5%_FalFld\Remodel3.ccf"
            sr_81 = "S:\US_Scenarios\ScenarioModeling\5%_RedIrr\Remodel3.ccf"
            sr_82 = "S:\US_Scenarios\ScenarioModeling\50%_RedIrr\Remodel3.ccf"
            sr_83 = "S:\US_Scenarios\ScenarioModeling\50%Seep\Remodel3.ccf"
            sr_84 = "S:\US_Scenarios\ScenarioModeling\60%Seep\Remodel3.ccf"
            sr_85 = "S:\US_Scenarios\ScenarioModeling\70%Seep\Remodel3.ccf"
            sr_86 = "S:\US_Scenarios\ScenarioModeling\80%Seep\Remodel3.ccf"
            sr_87 = "S:\US_Scenarios\ScenarioModeling\90%Seep\Remodel3.ccf"
            sr_88 = "S:\US_Scenarios\ScenarioModeling\Baseline\Remodel3.ccf"

        ElseIf region = "Downstream" Then
            FileNameBase = "DSModel_09"
            EndingTS = 292

            sr_1 = "S:\DS_Scenarios\ScenarioModeling\10%_AltApp\DSModel_09.ccf"
            sr_2 = "S:\DS_Scenarios\ScenarioModeling\10%_FalFld\DSModel_09.ccf"
            sr_3 = "S:\DS_Scenarios\ScenarioModeling\10%_RedIrr\DSModel_09.ccf"
            sr_4 = "S:\DS_Scenarios\ScenarioModeling\10%Seep\DSModel_09.ccf"
            sr_5 = "S:\DS_Scenarios\ScenarioModeling\15%_AltApp\DSModel_09.ccf"
            sr_6 = "S:\DS_Scenarios\ScenarioModeling\15%_FalFld\DSModel_09.ccf"
            sr_7 = "S:\DS_Scenarios\ScenarioModeling\15%_RedIrr\DSModel_09.ccf"
            sr_8 = "S:\DS_Scenarios\ScenarioModeling\20%_AltApp\DSModel_09.ccf"
            sr_9 = "S:\DS_Scenarios\ScenarioModeling\20%_FalFld\DSModel_09.ccf"
            sr_10 = "S:\DS_Scenarios\ScenarioModeling\20%_RedIrr\DSModel_09.ccf"
            sr_11 = "S:\DS_Scenarios\ScenarioModeling\20%Seep\DSModel_09.ccf"
            sr_12 = "S:\DS_Scenarios\ScenarioModeling\25%_AltApp\DSModel_09.ccf"
            sr_13 = "S:\DS_Scenarios\ScenarioModeling\25%_FalFld\DSModel_09.ccf"
            sr_14 = "S:\DS_Scenarios\ScenarioModeling\25%_FalFld_20%_RedIrr\DSModel_09.ccf"
            sr_15 = "S:\DS_Scenarios\ScenarioModeling\25%_FalFld_20%_RedIrr_30%_Seep\DSModel_09.ccf"
            sr_16 = "S:\DS_Scenarios\ScenarioModeling\25%_FalFld_20%_RedIrr_30%_Seep_Reform_pET\DSModel_09.ccf"
            sr_17 = "S:\DS_Scenarios\ScenarioModeling\25%_FalFld_20%_RedIrr_50%_Seep\DSModel_09.ccf"
            sr_18 = "S:\DS_Scenarios\ScenarioModeling\25%_FalFld_20%_RedIrr_50%_Seep_Reform_pET\DSModel_09.ccf"
            sr_19 = "S:\DS_Scenarios\ScenarioModeling\25%_FalFld_20%_RedIrr_80%_Seep\DSModel_09.ccf"
            sr_20 = "S:\DS_Scenarios\ScenarioModeling\25%_FalFld_20%_RedIrr_80%_Seep_Reform_pET\DSModel_09.ccf"
            sr_21 = "S:\DS_Scenarios\ScenarioModeling\25%_FalFld_20%_RedIrr_Reform_pET\DSModel_09.ccf"
            sr_22 = "S:\DS_Scenarios\ScenarioModeling\25%_FalFld_25%_RedIrr\DSModel_09.ccf"
            sr_23 = "S:\DS_Scenarios\ScenarioModeling\25%_FalFld_25%_RedIrr_30%_Seep\DSModel_09.ccf"
            sr_24 = "S:\DS_Scenarios\ScenarioModeling\25%_FalFld_25%_RedIrr_30%_Seep_Reform_pET\DSModel_09.ccf"
            sr_25 = "S:\DS_Scenarios\ScenarioModeling\25%_FalFld_25%_RedIrr_50%_Seep\DSModel_09.ccf"
            sr_26 = "S:\DS_Scenarios\ScenarioModeling\25%_FalFld_25%_RedIrr_50%_Seep_Reform_pET\DSModel_09.ccf"
            sr_27 = "S:\DS_Scenarios\ScenarioModeling\25%_FalFld_25%_RedIrr_80%_Seep\DSModel_09.ccf"
            sr_28 = "S:\DS_Scenarios\ScenarioModeling\25%_FalFld_25%_RedIrr_80%_Seep_Reform_pET\DSModel_09.ccf"
            sr_29 = "S:\DS_Scenarios\ScenarioModeling\25%_FalFld_25%_RedIrr_Reform_pET\DSModel_09.ccf"
            sr_30 = "S:\DS_Scenarios\ScenarioModeling\25%_FalFld_30%_RedIrr\DSModel_09.ccf"
            sr_31 = "S:\DS_Scenarios\ScenarioModeling\25%_FalFld_30%_RedIrr_30%_Seep\DSModel_09.ccf"
            sr_32 = "S:\DS_Scenarios\ScenarioModeling\25%_FalFld_30%_RedIrr_30%_Seep_Reform_pET\DSModel_09.ccf"
            sr_33 = "S:\DS_Scenarios\ScenarioModeling\25%_FalFld_30%_RedIrr_50%_Seep\DSModel_09.ccf"
            sr_34 = "S:\DS_Scenarios\ScenarioModeling\25%_FalFld_30%_RedIrr_50%_Seep_Reform_pET\DSModel_09.ccf"
            sr_35 = "S:\DS_Scenarios\ScenarioModeling\25%_FalFld_30%_RedIrr_80%_Seep\DSModel_09.ccf"
            sr_36 = "S:\DS_Scenarios\ScenarioModeling\25%_FalFld_30%_RedIrr_80%_Seep_Reform_pET\DSModel_09.ccf"
            sr_37 = "S:\DS_Scenarios\ScenarioModeling\25%_FalFld_30%_RedIrr_Reform_pET\DSModel_09.ccf"
            sr_38 = "S:\DS_Scenarios\ScenarioModeling\25%_FalFld_35%_RedIrr\DSModel_09.ccf"
            sr_39 = "S:\DS_Scenarios\ScenarioModeling\25%_FalFld_35%_RedIrr_30%_Seep\DSModel_09.ccf"
            sr_40 = "S:\DS_Scenarios\ScenarioModeling\25%_FalFld_35%_RedIrr_30%_Seep_Reform_pET\DSModel_09.ccf"
            sr_41 = "S:\DS_Scenarios\ScenarioModeling\25%_FalFld_35%_RedIrr_50%_Seep\DSModel_09.ccf"
            sr_42 = "S:\DS_Scenarios\ScenarioModeling\25%_FalFld_35%_RedIrr_50%_Seep_Reform_pET\DSModel_09.ccf"
            sr_43 = "S:\DS_Scenarios\ScenarioModeling\25%_FalFld_35%_RedIrr_80%_Seep\DSModel_09.ccf"
            sr_44 = "S:\DS_Scenarios\ScenarioModeling\25%_FalFld_35%_RedIrr_80%_Seep_Reform_pET\DSModel_09.ccf"
            sr_45 = "S:\DS_Scenarios\ScenarioModeling\25%_FalFld_35%_RedIrr_Reform_pET\DSModel_09.ccf"
            sr_46 = "S:\DS_Scenarios\ScenarioModeling\25%_FalFld_40%_RedIrr\DSModel_09.ccf"
            sr_47 = "S:\DS_Scenarios\ScenarioModeling\25%_FalFld_40%_RedIrr_30%_Seep\DSModel_09.ccf"
            sr_48 = "S:\DS_Scenarios\ScenarioModeling\25%_FalFld_40%_RedIrr_30%_Seep_Reform_pET\DSModel_09.ccf"
            sr_49 = "S:\DS_Scenarios\ScenarioModeling\25%_FalFld_40%_RedIrr_50%_Seep\DSModel_09.ccf"
            sr_50 = "S:\DS_Scenarios\ScenarioModeling\25%_FalFld_40%_RedIrr_50%_Seep_Reform_pET\DSModel_09.ccf"
            sr_51 = "S:\DS_Scenarios\ScenarioModeling\25%_FalFld_40%_RedIrr_80%_Seep\DSModel_09.ccf"
            sr_52 = "S:\DS_Scenarios\ScenarioModeling\25%_FalFld_40%_RedIrr_80%_Seep_Reform_pET\DSModel_09.ccf"
            sr_53 = "S:\DS_Scenarios\ScenarioModeling\25%_FalFld_40%_RedIrr_Reform_pET\DSModel_09.ccf"
            sr_54 = "S:\DS_Scenarios\ScenarioModeling\25%_FalFld_45%_RedIrr\DSModel_09.ccf"
            sr_55 = "S:\DS_Scenarios\ScenarioModeling\25%_FalFld_45%_RedIrr_30%_Seep\DSModel_09.ccf"
            sr_56 = "S:\DS_Scenarios\ScenarioModeling\25%_FalFld_45%_RedIrr_30%_Seep_Reform_pET\DSModel_09.ccf"
            sr_57 = "S:\DS_Scenarios\ScenarioModeling\25%_FalFld_45%_RedIrr_50%_Seep\DSModel_09.ccf"
            sr_58 = "S:\DS_Scenarios\ScenarioModeling\25%_FalFld_45%_RedIrr_50%_Seep_Reform_pET\DSModel_09.ccf"
            sr_59 = "S:\DS_Scenarios\ScenarioModeling\25%_FalFld_45%_RedIrr_80%_Seep\DSModel_09.ccf"
            sr_60 = "S:\DS_Scenarios\ScenarioModeling\25%_FalFld_45%_RedIrr_80%_Seep_Reform_pET\DSModel_09.ccf"
            sr_61 = "S:\DS_Scenarios\ScenarioModeling\25%_FalFld_45%_RedIrr_Reform_pET\DSModel_09.ccf"
            sr_62 = "S:\DS_Scenarios\ScenarioModeling\25%_FalFld_50%_RedIrr\DSModel_09.ccf"
            sr_63 = "S:\DS_Scenarios\ScenarioModeling\25%_FalFld_50%_RedIrr_30%_Seep\DSModel_09.ccf"
            sr_64 = "S:\DS_Scenarios\ScenarioModeling\25%_FalFld_50%_RedIrr_30%_Seep_Reform_pET\DSModel_09.ccf"
            sr_65 = "S:\DS_Scenarios\ScenarioModeling\25%_FalFld_50%_RedIrr_50%_Seep\DSModel_09.ccf"
            sr_66 = "S:\DS_Scenarios\ScenarioModeling\25%_FalFld_50%_RedIrr_50%_Seep_Reform_pET\DSModel_09.ccf"
            sr_67 = "S:\DS_Scenarios\ScenarioModeling\25%_FalFld_50%_RedIrr_80%_Seep\DSModel_09.ccf"
            sr_68 = "S:\DS_Scenarios\ScenarioModeling\25%_FalFld_50%_RedIrr_80%_Seep_Reform_pET\DSModel_09.ccf"
            sr_69 = "S:\DS_Scenarios\ScenarioModeling\25%_FalFld_50%_RedIrr_Reform_pET\DSModel_09.ccf"
            sr_70 = "S:\DS_Scenarios\ScenarioModeling\25%_FalFld_Reform_pET\DSModel_09.ccf"
            sr_71 = "S:\DS_Scenarios\ScenarioModeling\25%_RedIrr\DSModel_09.ccf"
            sr_72 = "S:\DS_Scenarios\ScenarioModeling\30%_RedIrr\DSModel_09.ccf"
            sr_73 = "S:\DS_Scenarios\ScenarioModeling\30%_RedIrr_80%_Seep\DSModel_09.ccf"
            sr_74 = "S:\DS_Scenarios\ScenarioModeling\30%Seep\DSModel_09.ccf"
            sr_75 = "S:\DS_Scenarios\ScenarioModeling\35%_RedIrr\DSModel_09.ccf"
            sr_76 = "S:\DS_Scenarios\ScenarioModeling\40%_RedIrr\DSModel_09.ccf"
            sr_77 = "S:\DS_Scenarios\ScenarioModeling\40%Seep\DSModel_09.ccf"
            sr_78 = "S:\DS_Scenarios\ScenarioModeling\45%_RedIrr\DSModel_09.ccf"
            sr_79 = "S:\DS_Scenarios\ScenarioModeling\5%_AltApp\DSModel_09.ccf"
            sr_80 = "S:\DS_Scenarios\ScenarioModeling\5%_FalFld\DSModel_09.ccf"
            sr_81 = "S:\DS_Scenarios\ScenarioModeling\5%_RedIrr\DSModel_09.ccf"
            sr_82 = "S:\DS_Scenarios\ScenarioModeling\50%_RedIrr\DSModel_09.ccf"
            sr_83 = "S:\DS_Scenarios\ScenarioModeling\50%Seep\DSModel_09.ccf"
            sr_84 = "S:\DS_Scenarios\ScenarioModeling\60%Seep\DSModel_09.ccf"
            sr_85 = "S:\DS_Scenarios\ScenarioModeling\70%Seep\DSModel_09.ccf"
            sr_86 = "S:\DS_Scenarios\ScenarioModeling\80%Seep\DSModel_09.ccf"
            sr_87 = "S:\DS_Scenarios\ScenarioModeling\90%Seep\DSModel_09.ccf"
            sr_88 = "S:\DS_Scenarios\ScenarioModeling\Baseline\DSModel_09.ccf"
        End If

        ReDim RiverFluxVals(EndingTS, 88)
        Try

            i = FreeFile()
            Dim fs As FileStream
            Dim m_arr() As String


            For Scenario = 1 To 88
                Select Case Scenario
                    Case 1
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_1
                    Case 2
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_2
                    Case 3
                        FileNameBase = sr_3
                    Case 4
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_4
                    Case 5
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_5
                    Case 6
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_6
                    Case 7
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_7
                    Case 8
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_8
                    Case 9
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_9
                    Case 10
                        FileNameBase = sr_10
                    Case 11
                        FileNameBase = sr_11
                    Case 12
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_12
                    Case 13
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_13
                    Case 14
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_14
                    Case 15
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_15
                    Case 16
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_16
                    Case 17
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_17
                    Case 18
                        FileNameBase = sr_18
                    Case 19
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_19
                    Case 20
                        FileNameBase = sr_20
                    Case 21
                        FileNameBase = sr_21
                    Case 22
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_22
                    Case 23
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_23
                    Case 24
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_24
                    Case 25
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_25
                    Case 26
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_26
                    Case 27
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_27
                    Case 28
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_28
                    Case 29
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_29
                    Case 30
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_30
                    Case 31
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_31
                    Case 32
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_32
                    Case 33
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_33
                    Case 34
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_34
                    Case 35
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_35
                    Case 36
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_36
                    Case 37
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_37
                    Case 38
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_38
                    Case 39
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_39
                    Case 40
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_40
                    Case 41
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_41
                    Case 42
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_42
                    Case 43
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_43
                    Case 44
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_44
                    Case 45
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_45
                    Case 46
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_46
                    Case 47
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_47
                    Case 48
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_48
                    Case 49
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_49
                    Case 50
                        FileNameBase = sr_50
                    Case 51
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_51
                    Case 52
                        FileNameBase = sr_52
                    Case 53
                        FileNameBase = sr_53
                    Case 54
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_54
                    Case 55
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_55
                    Case 56
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_56
                    Case 57
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_57
                    Case 58
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_58
                    Case 59
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_59
                    Case 60
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_60
                    Case 61
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_61
                    Case 62
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_62
                    Case 63
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_63
                    Case 64
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_64
                    Case 65
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_65
                    Case 66
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_66
                    Case 67
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_67
                    Case 68
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_68
                    Case 69
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_69
                    Case 70
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_70
                    Case 71
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_71
                    Case 72
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_72
                    Case 73
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_73
                    Case 74
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_74
                    Case 75
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_75
                    Case 76
                        FileNameBase = sr_76
                    Case 77
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_77
                    Case 78
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_78
                    Case 79
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_79
                    Case 80
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_80
                    Case 81
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_81
                    Case 82
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_82
                    Case 83
                        FileNameBase = sr_83
                    Case 84
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_84
                    Case 85
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_85
                    Case 86
                        FileNameBase = sr_86
                    Case 87
                        GoTo 10                 'don't need this scenario right now
                        FileNameBase = sr_87
                    Case 88
                        FileNameBase = sr_88
                End Select

                fs = New IO.FileStream(FileNameBase, FileMode.Open, FileAccess.Read)
                ' Create the writer for data.
                Dim r As New BinaryReader(fs)
                'file Bytes size
                retval = fs.Length


                If IsNewerMODFLOWOutput Then
                    ' Kstps - counts the timesteps
                    Kstps = 0
                    Do
                        Kstps += 1

                        ' Documentation found at http://water.usgs.gov/nrp/gwsoftware/modflow2005/Guide/index.html
                        '  in the Frequently Asked Questions section (a weird place for its documentation)
                        ' Timestep, Stress period, and description
                        TimeStep = r.ReadInt32()
                        TimeStep = r.ReadInt32()
                        m_arr = Split(FileNameBase, "\")
                        If Not TimeStep = old_ts Then Console.WriteLine("Working on Stress Period " & TimeStep & " : " & m_arr(m_arr.Length - 2))
                        old_ts = TimeStep

                        Ftext = r.ReadChars(16)
                        ' Number of columns, rows, and layers
                        Ncol = r.ReadInt32()
                        Nrow = r.ReadInt32()
                        Nlay = Math.Abs(r.ReadInt32())
                        ' Type of data
                        Dim ITYPE As Integer = r.ReadInt32()
                        For i = 1 To 3
                            trashsingle = r.ReadSingle()
                        Next i
                        NValsPerCell = 1
                        If ITYPE = 5 Then NValsPerCell = r.ReadInt32()
                        For y = 1 To NValsPerCell - 1
                            tmpText = r.ReadChars(16)
                        Next y
                        Dim NLIST As Integer = 0
                        If ITYPE = 2 Or ITYPE = 5 Then NLIST = r.ReadInt32()

                        ' Make sure just to skip the values that aren't of interest
                        SkipValues = False
                        If BeginningTS <= TimeStep AndAlso (EndingTS = -1 OrElse TimeStep <= EndingTS) Then
                            TimeStep = TimeStep - BeginningTS + 1
                        Else
                            SkipValues = True
                        End If

                        Select Case Ftext
                            Case "   CONSTANT HEAD", "FLOW RIGHT FACE ", "FLOW FRONT FACE ", "FLOW LOWER FACE "
                                SkipValues = True
                        End Select

                        If Not SkipValues Then
                            ' Initialize output arrays
                            layerFlux = Nothing
                            layerFlux = New Object(Nlay) {}
                            For Layer = 1 To Nlay
                                layerFlux(Layer) = New Single(Ncol * Nrow) {}
                            Next Layer
                        End If

                        ' Read the values from the file
                        Select Case ITYPE
                            Case 0, 1 '3D array of values
                                If SkipValues Then
                                    fs.Position += Nlay * Nrow * Ncol * 4
                                Else
                                    For Layer = 1 To Nlay
                                        For Rows = 1 To Nrow
                                            For Cols = 1 To Ncol
                                                layerFlux(Layer)((Rows - 1) * Ncol + Cols) = r.ReadSingle()
                                            Next Cols
                                        Next Rows
                                    Next Layer
                                End If
                            Case 2, 5 'list of cells and associated values
                                If SkipValues Then
                                    fs.Position += NLIST * (4 + NValsPerCell * 4)
                                Else
                                    For y = 1 To NLIST
                                        CellID = r.ReadInt32()
                                        LayerID = ((CellID - ((CellID - 1) Mod (Ncol * Nrow) + 1)) / (Ncol * Nrow) + 1) ' LayerID starts at one
                                        CellID = (CellID - 1) Mod (Ncol * Nrow) + 1
                                        layerFlux(LayerID)(CellID) += r.ReadSingle()
                                        For i = 1 To NValsPerCell - 1
                                            TempVal = r.ReadSingle()
                                        Next i
                                    Next y
                                End If
                            Case 3    '2D layer indicator array followed by a 2D array of values
                                If SkipValues Then
                                    fs.Position += Nrow * Ncol * 4 * 2
                                Else
                                    Dim layerIDs() As Integer = New Integer(Ncol * Nrow) {}
                                    For Rows = 1 To Nrow
                                        For Cols = 1 To Ncol
                                            layerIDs((Rows - 1) * Ncol + Cols) = r.ReadInt32()
                                        Next
                                    Next
                                    For Rows = 1 To Nrow
                                        For Cols = 1 To Ncol
                                            CellID = (Rows - 1) * Ncol + Cols
                                            layerFlux(layerIDs(CellID))(CellID) = r.ReadSingle()
                                        Next
                                    Next
                                End If
                            Case 4    '2D array of values associated with layer 1 
                                If SkipValues Then
                                    fs.Position += Nrow * Ncol * 4
                                Else
                                    For Rows = 1 To Nrow
                                        For Cols = 1 To Ncol
                                            CellID = (Rows - 1) * Ncol + Cols
                                            layerFlux(1)(CellID) = r.ReadSingle()
                                        Next
                                    Next
                                End If
                        End Select

                        ' Place layerFlux array in specific arrays that hold values at each timestep
                        If Not SkipValues Then
                            Select Case Ftext
                                'Case "   CONSTANT HEAD"
                                'Case "FLOW RIGHT FACE "
                                'Case "FLOW FRONT FACE "
                                'Case "FLOW LOWER FACE "
                                Case "           WELLS"
                                    ReDim Preserve WellsFluxVals(TimeStep)
                                    WellsFluxVals(TimeStep) = layerFlux.Clone()
                                Case "          DRAINS"
                                    ReDim Preserve DrainFluxVals(TimeStep)
                                    DrainFluxVals(TimeStep) = layerFlux.Clone()
                                Case "   RIVER LEAKAGE"
                                    RiverFluxVals(TimeStep, Scenario) = layerFlux.Clone()
                                Case " HEAD DEP BOUNDS"
                                    ReDim Preserve GHeadsFluxVals(TimeStep)
                                    GHeadsFluxVals(TimeStep) = layerFlux.Clone()
                                Case "              ET"
                                    ReDim Preserve ETFluxVals(TimeStep)
                                    ETFluxVals(TimeStep) = layerFlux.Clone()
                                Case "        RECHARGE"
                                    ReDim Preserve RechFluxVals(TimeStep)
                                    RechFluxVals(TimeStep) = layerFlux.Clone()
                                Case "         STORAGE"
                                    ReDim Preserve StorageVals(TimeStep)
                                    StorageVals(TimeStep) = layerFlux.Clone()
                            End Select
                        End If
                    Loop While (fs.Position < fs.Length)
                End If
                Kstps = TimeStep
                If EndingTS = -1 Then EndingTS = BeginningTS + TimeStep - 1
                r.Close()
                fs.Close()
                r = Nothing
                fs = Nothing
10:         Next Scenario
        Catch ex As Exception
            MsgBox("Error obtaining MODFLOW data..." & vbCrLf & ex.Message & vbCrLf & ex.StackTrace)
        End Try

        'Pass RiverFluxVals to a function and deal with it there
        Calc_Accretion_Depletion_Percentages(RiverFluxVals, Nrow, Ncol, Nlay, EndingTS, region)

    End Sub

    Private Function Calc_Accretion_Depletion_Percentages(ByVal RiverFluxVals As Object, ByVal num_row As Integer, ByVal num_col As Integer, ByVal num_lay As Integer, ByVal num_ts As Integer, ByVal region As String)

        Dim cell_array(num_row, num_col, num_lay, 9, 13)    'Up to 9 yr slots and 13 scenario slots

        Dim num_scenario As Integer
        Dim ts As Integer
        Dim i As Integer
        Dim j As Integer
        Dim k As Integer
        Dim yr As Integer
        Dim num_yr As Integer
        Dim scenario As Integer

        'initialize array
        For num_scenario = 1 To 13
            For ts = 1 To 9
                For k = 1 To 2
                    For i = 1 To num_row
                        For j = 1 To num_col
                            cell_array(i, j, k, yr, num_scenario) = 0
                        Next j
                    Next i
                Next k
            Next ts
        Next num_scenario

        num_scenario = 1
        For num_scenario = 1 To 13  'Just start with the 13 scenarios used in the barplots

            Select Case num_scenario
                Case 1
                    scenario = 88   'baseline
                Case 2
                    scenario = 11   '20% Seep Red
                Case 3
                    scenario = 83   '50% Seep Red
                Case 4
                    scenario = 86   '80% Seep Red
                Case 5
                    scenario = 3    '10% Irr Red
                Case 6
                    scenario = 10   '20% Irr Red
                Case 7
                    scenario = 76   '40% Irr Red
                Case 8
                    scenario = 21   '25% Fal Fld 20% Irr Red
                Case 9
                    scenario = 53   '25% Fal Fld 40% Irr Red
                Case 10
                    scenario = 18   '25% Fal Fld 20% Irr Red 50% Seep Red
                Case 11
                    scenario = 20   '25% Fal Fld 20% Irr Red 80% Seep Red
                Case 12
                    scenario = 50   '25% Fal Fld 40% Irr Red 50% Seep Red
                Case 13
                    scenario = 52   '25% Fal Fld 40% Irr Red 80% Seep Red
            End Select

            For ts = 1 To num_ts
                If region = "Upstream" Then
                    If ts <= 39 Then
                        yr = 1              '1999
                    ElseIf ts <= 92 Then
                        yr = 2              '2000
                    ElseIf ts <= 144 Then
                        yr = 3              '2001
                    ElseIf ts <= 196 Then
                        yr = 4              '2002
                    ElseIf ts <= 248 Then
                        yr = 5              '2003
                    ElseIf ts <= 300 Then
                        yr = 6              '2004
                    ElseIf ts <= 352 Then
                        yr = 7              '2005
                    ElseIf ts <= 405 Then
                        yr = 8              '2006
                    Else
                        yr = 9              '2007
                    End If
                ElseIf region = "Downstream" Then
                    If ts <= 40 Then
                        yr = 1              '2002
                    ElseIf ts <= 92 Then
                        yr = 2              '2003
                    ElseIf ts <= 144 Then
                        yr = 3              '2004
                    ElseIf ts <= 196 Then
                        yr = 4              '2005
                    ElseIf ts <= 249 Then
                        yr = 5              '2006
                    Else
                        yr = 6              '2007
                    End If
                End If

                For k = 1 To 2
                    For i = 1 To num_row
                        For j = 1 To num_col
                            'Sort the RiverFluxVals into an organized spatial array
                            cell_array(i, j, k, yr, num_scenario) += RiverFluxVals(ts, scenario)(k)((i - 1) * num_col + j)
                        Next j
                    Next i
                Next k
            Next ts
            Console.WriteLine("Working on scenario " & num_scenario & " of 13")
        Next num_scenario

        'Need to read the cell groups 
        ' ******* Note that not all of the cells in the main branch list are going to appear in the array *********
        ' ******* May need to add some error handling.
        Dim sr As StreamReader
        Dim line As String
        Dim m_arr() As String
        Dim canal As String
        Dim kk As Integer
        Dim ii As Integer
        Dim jj As Integer
        Dim m_table As DataTable
        m_table = New DataTable("Water_Bodies_and_Cells")
        Dim m_col As DataColumn
        Dim m_row As DataRow

        m_col = New DataColumn
        With m_col
            .ColumnName = "Lay"
            .DataType = GetType(System.Int32)
        End With
        m_table.Columns.Add(m_col)

        m_col = New DataColumn
        With m_col
            .ColumnName = "Row"
            .DataType = GetType(System.Int32)
        End With
        m_table.Columns.Add(m_col)

        m_col = New DataColumn
        With m_col
            .ColumnName = "Col"
            .DataType = GetType(System.Int32)
        End With
        m_table.Columns.Add(m_col)

        m_col = New DataColumn
        With m_col
            .ColumnName = "Water_Body"
            .DataType = GetType(System.String)
        End With
        m_table.Columns.Add(m_col)

        'Set up datareader
        If region = "Upstream" Then
            sr = New StreamReader(Directory.GetCurrentDirectory() & "\CellByWaterBodies_US.txt")
            num_yr = 9
        ElseIf region = "Downstream" Then
            sr = New StreamReader(Directory.GetCurrentDirectory() & "\CellByWaterBodies_DS.txt")
            num_yr = 6
        End If

        'Read and store in a datatable all of the cell and associated water body information
        line = sr.ReadLine()
        While Not line = ""
            If Char.IsLetter(line.Chars(0)) Then
                m_arr = Split(line, vbTab)
                canal = m_arr(0)
            Else
                m_row = m_table.NewRow()
                m_arr = Split(line, vbTab)
                kk = m_arr(0)
                ii = m_arr(1)
                jj = m_arr(2)
                m_row(0) = kk
                m_row(1) = ii
                m_row(2) = jj
                m_row(3) = canal
                m_table.Rows.Add(m_row)
            End If
            line = sr.ReadLine()
        End While
        sr.Close()

        'For starters, compare only the baseline to scenarios
        Dim AccretionDepletion_pct(num_row, num_col, num_lay, 9, 13) As Single
        num_scenario = 13
        For scenario = 2 To num_scenario
            For yr = 1 To num_yr
                For k = 1 To 2
                    For i = 1 To num_row
                        For j = 1 To num_col
                            If Not cell_array(i, j, k, yr, scenario) = 0 Then
                                AccretionDepletion_pct(i, j, k, yr, scenario) = (cell_array(i, j, k, yr, scenario) - cell_array(i, j, k, yr, 1)) / cell_array(i, j, k, yr, 1)
                            End If
                        Next j
                    Next i
                Next k
            Next yr
        Next scenario

        Dim sw As StreamWriter

        'Spit out an example raster for the 25% Fal 20% Red Irr scenario
        If region = "Upstream" Then
            sw = New StreamWriter(Directory.GetCurrentDirectory() & "\US_AccDep_Ras_25%FalFld20%RedIrr.txt")
            sw.WriteLine("ncols         213")
            sw.WriteLine("nrows         127")
            sw.WriteLine("xllcorner     597733")
            sw.WriteLine("yllcorner     4195257")
            sw.WriteLine("cellsize      250")
            sw.WriteLine("NODATA_value  -999")
        ElseIf region = "Downstream" Then
            sw = New StreamWriter(Directory.GetCurrentDirectory() & "\DS_AccDep_Ras_25%FalFld20%RedIrr.txt")
            sw.WriteLine("ncols         217")
            sw.WriteLine("nrows         102")
            sw.WriteLine("xllcorner     705984")
            sw.WriteLine("yllcorner     4211006")
            sw.WriteLine("cellsize      250")
            sw.WriteLine("NODATA_value  -999")
        End If

        'for 2007 only for now
        For i = 1 To num_row
            For j = 1 To num_col
                sw.Write(Format(AccretionDepletion_pct(i, j, 1, num_yr, 8), "0.00").PadLeft(7))     'only layer 1, only 2007, only 25% FalFld 20% RedIrr scenario
            Next j
            sw.Write(vbNewLine)
        Next i
        sw.Close()

        'Probably want to spit out the output in a table form for the paper.
        'US: Upstream of Fort Lyon diversion water bodies: "PH-On", "TC1-On", "TC2-On", "Main Branch 1"
        'US: Downstream of Fort Lyon diversion water bodies: "CA-On", "AndrsnAryo", "HrsCrk1-On", "HrsCrk2-On", "Main Branch 2"

        'DS: Upstream of Buffalo diversion water bodies: "Main Branch 1", "May Valley Drain 1", "May Valley Drain 2", "Big Sandy", 
        'DS: Downstream of Buffalo diversion water bodies: "Main Branch 2", "Deadman Ditch", "East Deadman Ditch", "Wolf Creek", "Granada Drain 1", "Granada Drain 2", "North Holly Drain", "South Holly Drain", "Wild Horse Creek 1", "Wild Horse Creek 2", "Pauls Arroyo"
        Dim m_rows() As DataRow
        Dim AccretionDepletion_totals(9, 13, 2) As Single  'Up to possible years, 13 scenarios, 2 sub-regions

        'initialize array
        For scenario = 1 To num_scenario
            For yr = 1 To num_yr
                For ii = 1 To 2
                    AccretionDepletion_totals(yr, scenario, ii) = 0
                Next
            Next yr
        Next scenario

        sw = New StreamWriter(Directory.GetCurrentDirectory() & "\AccDep_Checker.txt")
        sw.WriteLine("row" & vbTab & "col" & vbTab & "lay" & vbTab & "water body" & vbTab & "yr_1_x" & vbTab & "scenario_1_13" & vbTab & "CellGainLoss")
        For scenario = 1 To num_scenario
            For yr = 1 To num_yr
                For ii = 1 To 2     'Two distinct regions being analyzed in each region
                    If region = "Upstream" And ii = 1 Then
                        m_rows = m_table.Select("Water_Body = 'PH-On' OR Water_Body = 'TC1-On' OR Water_Body = 'TC2-On' OR Water_Body = 'Main Branch 1'")
                    ElseIf region = "Upstream" And ii = 2 Then
                        m_rows = m_table.Select("Water_Body = 'CA-On' OR Water_Body = 'AndrsnAryo' OR Water_Body = 'HrsCrk1-On' OR Water_Body = 'HrsCrk2-On' OR Water_Body = 'Main Branch 2'")
                    ElseIf region = "Downstream" And ii = 1 Then
                        m_rows = m_table.Select("Water_Body = 'Main Branch 1' OR Water_Body = 'May Valley Drain 1' OR Water_Body = 'May Valley Drain 2' OR Water_Body = 'Big Sandy'")
                    ElseIf region = "Downstream" And ii = 2 Then
                        m_rows = m_table.Select("Water_Body = 'Main Branch 2' OR Water_Body = 'Deadman Ditch' OR Water_Body = 'East Deadman Ditch' OR Water_Body = 'Wolf Creek' OR Water_Body = 'Granada Drain 1' OR Water_Body = 'Granada Drain 2' OR Water_Body = 'North Holly Drain' OR Water_Body = 'South Holly Drain' OR Water_Body = 'Wild Horse Creek 1' OR Water_Body = 'Wild Horse Creek 2' OR Water_Body = 'Pauls Arroyo'")
                    End If
                    'For each returned row
                    For jj = 0 To m_rows.Length() - 1
                        AccretionDepletion_totals(yr, scenario, ii) += cell_array(m_rows(jj)(1), m_rows(jj)(2), m_rows(jj)(0), yr, scenario)

                        'an output file for trying to find out what the heck is going on...
                        sw.WriteLine(m_rows(jj)(1) & vbTab & m_rows(jj)(2) & vbTab & m_rows(jj)(0) & vbTab & m_rows(jj)(3) & vbTab & CStr(yr) & vbTab & CStr(scenario) & vbTab & Format(cell_array(m_rows(jj)(1), m_rows(jj)(2), m_rows(jj)(0), yr, scenario), "0.0000"))
                    Next jj
                Next ii
            Next yr
        Next scenario
        sw.Close()

        'Now dump the output to a table
        If region = "Upstream" Then
            sw = New StreamWriter(Directory.GetCurrentDirectory() & "\US_table_of_total_AccretionDepletion.txt")
        ElseIf region = "Downstream" Then
            sw = New StreamWriter(Directory.GetCurrentDirectory() & "\DS_table_of_total_AccretionDepletion.txt")
        End If

        For scenario = 2 To num_scenario
            For ii = 1 To 2
                For yr = 1 To num_yr
                    sw.Write(Format((AccretionDepletion_totals(yr, scenario, ii) - AccretionDepletion_totals(yr, 1, ii)) / AccretionDepletion_totals(yr, 1, ii), "0.000") & vbTab)
                Next yr
                sw.Write(vbNewLine)
            Next ii
        Next scenario
        sw.Close()

    End Function



End Class
