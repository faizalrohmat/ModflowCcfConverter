using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModflowCcfConverter
{
    class Converter
    {
        public void ConverterTool()
        {
            #region Variable definitions
            string region;
            int num_files;
            int num_ts;

            region = "Downstream";

            object[] wellsFluxVals, DrainFluxVals, GHeadsFluxVals, ETFluxVals, RechFluxVals, StorageVals;
            object[,] RiverFluxVals;

            #region scenarios string placeholder
            string sr_1;
            string sr_2;
            string sr_3;
            string sr_4;
            string sr_5;
            string sr_6;
            string sr_7;
            string sr_8;
            string sr_9;
            string sr_10;
            string sr_11;
            string sr_12;
            string sr_13;
            string sr_14;
            string sr_15;
            string sr_16;
            string sr_17;
            string sr_18;
            string sr_19;
            string sr_20;
            string sr_21;
            string sr_22;
            string sr_23;
            string sr_24;
            string sr_25;
            string sr_26;
            string sr_27;
            string sr_28;
            string sr_29;
            string sr_30;
            string sr_31;
            string sr_32;
            string sr_33;
            string sr_34;
            string sr_35;
            string sr_36;
            string sr_37;
            string sr_38;
            string sr_39;
            string sr_40;
            string sr_41;
            string sr_42;
            string sr_43;
            string sr_44;
            string sr_45;
            string sr_46;
            string sr_47;
            string sr_48;
            string sr_49;
            string sr_50;
            string sr_51;
            string sr_52;
            string sr_53;
            string sr_54;
            string sr_55;
            string sr_56;
            string sr_57;
            string sr_58;
            string sr_59;
            string sr_60;
            string sr_61;
            string sr_62;
            string sr_63;
            string sr_64;
            string sr_65;
            string sr_66;
            string sr_67;
            string sr_68;
            string sr_69;
            string sr_70;
            string sr_71;
            string sr_72;
            string sr_73;
            string sr_74;
            string sr_75;
            string sr_76;
            string sr_77;
            string sr_78;
            string sr_79;
            string sr_80;
            string sr_81;
            string sr_82;
            string sr_83;
            string sr_84;
            string sr_85;
            string sr_86;
            string sr_87;
            string sr_88;
            #endregion

            int Nrow, Ncol, Nlay, Kstps, Cols, Rows, Layer, TimeStep;

            object retval, flowfilename;
            int trashlong, trashlong2;
            float trashsingle;

            string Ftext = new string(' ', 16);
            string tmpText = new string(' ', 16);

            int i, x, y, CellID;
            int ByteCount, totalperTS;

            float TempVal;

            object[] layerFlux = null;

            int LayerID, NValsPerCell;
            bool SkipValues;
            bool IsNewerMODFLOWOutput = true;
            string FileNameBase;

            int BeginningTS, EndingTS, old_ts, Scenario;
            old_ts = 1;
            EndingTS = 0;

            #endregion

            BeginningTS = 1;

            if (region == "Upstream")
            {
                FileNameBase = "Remodel3";
                EndingTS = 448;

                #region AssigningPath for upstream
                sr_1 = @"S:\US_Scenarios\ScenarioModeling\10%_AltApp\Remodel3.ccf";
                sr_2 = @"S:\US_Scenarios\ScenarioModeling\10%_FalFld\Remodel3.ccf";
                sr_3 = @"S:\US_Scenarios\ScenarioModeling\10%_RedIrr\Remodel3.ccf";
                sr_4 = @"S:\US_Scenarios\ScenarioModeling\10%Seep\Remodel3.ccf";
                sr_5 = @"S:\US_Scenarios\ScenarioModeling\15%_AltApp\Remodel3.ccf";
                sr_6 = @"S:\US_Scenarios\ScenarioModeling\15%_FalFld\Remodel3.ccf";
                sr_7 = @"S:\US_Scenarios\ScenarioModeling\15%_RedIrr\Remodel3.ccf";
                sr_8 = @"S:\US_Scenarios\ScenarioModeling\20%_AltApp\Remodel3.ccf";
                sr_9 = @"S:\US_Scenarios\ScenarioModeling\20%_FalFld\Remodel3.ccf";
                sr_10 = @"S:\US_Scenarios\ScenarioModeling\20%_RedIrr\Remodel3.ccf";
                sr_11 = @"S:\US_Scenarios\ScenarioModeling\20%Seep\Remodel3.ccf";
                sr_12 = @"S:\US_Scenarios\ScenarioModeling\25%_AltApp\Remodel3.ccf";
                sr_13 = @"S:\US_Scenarios\ScenarioModeling\25%_FalFld\Remodel3.ccf";
                sr_14 = @"S:\US_Scenarios\ScenarioModeling\25%_FalFld_20%_RedIrr\Remodel3.ccf";
                sr_15 = @"S:\US_Scenarios\ScenarioModeling\25%_FalFld_20%_RedIrr_30%_Seep\Remodel3.ccf";
                sr_16 = @"S:\US_Scenarios\ScenarioModeling\25%_FalFld_20%_RedIrr_30%_Seep_Reform_pET\Remodel3.ccf";
                sr_17 = @"S:\US_Scenarios\ScenarioModeling\25%_FalFld_20%_RedIrr_50%_Seep\Remodel3.ccf";
                sr_18 = @"S:\US_Scenarios\ScenarioModeling\25%_FalFld_20%_RedIrr_50%_Seep_Reform_pET\Remodel3.ccf";
                sr_19 = @"S:\US_Scenarios\ScenarioModeling\25%_FalFld_20%_RedIrr_80%_Seep\Remodel3.ccf";
                sr_20 = @"S:\US_Scenarios\ScenarioModeling\25%_FalFld_20%_RedIrr_80%_Seep_Reform_pET\Remodel3.ccf";
                sr_21 = @"S:\US_Scenarios\ScenarioModeling\25%_FalFld_20%_RedIrr_Reform_pET\Remodel3.ccf";
                sr_22 = @"S:\US_Scenarios\ScenarioModeling\25%_FalFld_25%_RedIrr\Remodel3.ccf";
                sr_23 = @"S:\US_Scenarios\ScenarioModeling\25%_FalFld_25%_RedIrr_30%_Seep\Remodel3.ccf";
                sr_24 = @"S:\US_Scenarios\ScenarioModeling\25%_FalFld_25%_RedIrr_30%_Seep_Reform_pET\Remodel3.ccf";
                sr_25 = @"S:\US_Scenarios\ScenarioModeling\25%_FalFld_25%_RedIrr_50%_Seep\Remodel3.ccf";
                sr_26 = @"S:\US_Scenarios\ScenarioModeling\25%_FalFld_25%_RedIrr_50%_Seep_Reform_pET\Remodel3.ccf";
                sr_27 = @"S:\US_Scenarios\ScenarioModeling\25%_FalFld_25%_RedIrr_80%_Seep\Remodel3.ccf";
                sr_28 = @"S:\US_Scenarios\ScenarioModeling\25%_FalFld_25%_RedIrr_80%_Seep_Reform_pET\Remodel3.ccf";
                sr_29 = @"S:\US_Scenarios\ScenarioModeling\25%_FalFld_25%_RedIrr_Reform_pET\Remodel3.ccf";
                sr_30 = @"S:\US_Scenarios\ScenarioModeling\25%_FalFld_30%_RedIrr\Remodel3.ccf";
                sr_31 = @"S:\US_Scenarios\ScenarioModeling\25%_FalFld_30%_RedIrr_30%_Seep\Remodel3.ccf";
                sr_32 = @"S:\US_Scenarios\ScenarioModeling\25%_FalFld_30%_RedIrr_30%_Seep_Reform_pET\Remodel3.ccf";
                sr_33 = @"S:\US_Scenarios\ScenarioModeling\25%_FalFld_30%_RedIrr_50%_Seep\Remodel3.ccf";
                sr_34 = @"S:\US_Scenarios\ScenarioModeling\25%_FalFld_30%_RedIrr_50%_Seep_Reform_pET\Remodel3.ccf";
                sr_35 = @"S:\US_Scenarios\ScenarioModeling\25%_FalFld_30%_RedIrr_80%_Seep\Remodel3.ccf";
                sr_36 = @"S:\US_Scenarios\ScenarioModeling\25%_FalFld_30%_RedIrr_80%_Seep_Reform_pET\Remodel3.ccf";
                sr_37 = @"S:\US_Scenarios\ScenarioModeling\25%_FalFld_30%_RedIrr_Reform_pET\Remodel3.ccf";
                sr_38 = @"S:\US_Scenarios\ScenarioModeling\25%_FalFld_35%_RedIrr\Remodel3.ccf";
                sr_39 = @"S:\US_Scenarios\ScenarioModeling\25%_FalFld_35%_RedIrr_30%_Seep\Remodel3.ccf";
                sr_40 = @"S:\US_Scenarios\ScenarioModeling\25%_FalFld_35%_RedIrr_30%_Seep_Reform_pET\Remodel3.ccf";
                sr_41 = @"S:\US_Scenarios\ScenarioModeling\25%_FalFld_35%_RedIrr_50%_Seep\Remodel3.ccf";
                sr_42 = @"S:\US_Scenarios\ScenarioModeling\25%_FalFld_35%_RedIrr_50%_Seep_Reform_pET\Remodel3.ccf";
                sr_43 = @"S:\US_Scenarios\ScenarioModeling\25%_FalFld_35%_RedIrr_80%_Seep\Remodel3.ccf";
                sr_44 = @"S:\US_Scenarios\ScenarioModeling\25%_FalFld_35%_RedIrr_80%_Seep_Reform_pET\Remodel3.ccf";
                sr_45 = @"S:\US_Scenarios\ScenarioModeling\25%_FalFld_35%_RedIrr_Reform_pET\Remodel3.ccf";
                sr_46 = @"S:\US_Scenarios\ScenarioModeling\25%_FalFld_40%_RedIrr\Remodel3.ccf";
                sr_47 = @"S:\US_Scenarios\ScenarioModeling\25%_FalFld_40%_RedIrr_30%_Seep\Remodel3.ccf";
                sr_48 = @"S:\US_Scenarios\ScenarioModeling\25%_FalFld_40%_RedIrr_30%_Seep_Reform_pET\Remodel3.ccf";
                sr_49 = @"S:\US_Scenarios\ScenarioModeling\25%_FalFld_40%_RedIrr_50%_Seep\Remodel3.ccf";
                sr_50 = @"S:\US_Scenarios\ScenarioModeling\25%_FalFld_40%_RedIrr_50%_Seep_Reform_pET\Remodel3.ccf";
                sr_51 = @"S:\US_Scenarios\ScenarioModeling\25%_FalFld_40%_RedIrr_80%_Seep\Remodel3.ccf";
                sr_52 = @"S:\US_Scenarios\ScenarioModeling\25%_FalFld_40%_RedIrr_80%_Seep_Reform_pET\Remodel3.ccf";
                sr_53 = @"S:\US_Scenarios\ScenarioModeling\25%_FalFld_40%_RedIrr_Reform_pET\Remodel3.ccf";
                sr_54 = @"S:\US_Scenarios\ScenarioModeling\25%_FalFld_45%_RedIrr\Remodel3.ccf";
                sr_55 = @"S:\US_Scenarios\ScenarioModeling\25%_FalFld_45%_RedIrr_30%_Seep\Remodel3.ccf";
                sr_56 = @"S:\US_Scenarios\ScenarioModeling\25%_FalFld_45%_RedIrr_30%_Seep_Reform_pET\Remodel3.ccf";
                sr_57 = @"S:\US_Scenarios\ScenarioModeling\25%_FalFld_45%_RedIrr_50%_Seep\Remodel3.ccf";
                sr_58 = @"S:\US_Scenarios\ScenarioModeling\25%_FalFld_45%_RedIrr_50%_Seep_Reform_pET\Remodel3.ccf";
                sr_59 = @"S:\US_Scenarios\ScenarioModeling\25%_FalFld_45%_RedIrr_80%_Seep\Remodel3.ccf";
                sr_60 = @"S:\US_Scenarios\ScenarioModeling\25%_FalFld_45%_RedIrr_80%_Seep_Reform_pET\Remodel3.ccf";
                sr_61 = @"S:\US_Scenarios\ScenarioModeling\25%_FalFld_45%_RedIrr_Reform_pET\Remodel3.ccf";
                sr_62 = @"S:\US_Scenarios\ScenarioModeling\25%_FalFld_50%_RedIrr\Remodel3.ccf";
                sr_63 = @"S:\US_Scenarios\ScenarioModeling\25%_FalFld_50%_RedIrr_30%_Seep\Remodel3.ccf";
                sr_64 = @"S:\US_Scenarios\ScenarioModeling\25%_FalFld_50%_RedIrr_30%_Seep_Reform_pET\Remodel3.ccf";
                sr_65 = @"S:\US_Scenarios\ScenarioModeling\25%_FalFld_50%_RedIrr_50%_Seep\Remodel3.ccf";
                sr_66 = @"S:\US_Scenarios\ScenarioModeling\25%_FalFld_50%_RedIrr_50%_Seep_Reform_pET\Remodel3.ccf";
                sr_67 = @"S:\US_Scenarios\ScenarioModeling\25%_FalFld_50%_RedIrr_80%_Seep\Remodel3.ccf";
                sr_68 = @"S:\US_Scenarios\ScenarioModeling\25%_FalFld_50%_RedIrr_80%_Seep_Reform_pET\Remodel3.ccf";
                sr_69 = @"S:\US_Scenarios\ScenarioModeling\25%_FalFld_50%_RedIrr_Reform_pET\Remodel3.ccf";
                sr_70 = @"S:\US_Scenarios\ScenarioModeling\25%_FalFld_Reform_pET\Remodel3.ccf";
                sr_71 = @"S:\US_Scenarios\ScenarioModeling\25%_RedIrr\Remodel3.ccf";
                sr_72 = @"S:\US_Scenarios\ScenarioModeling\30%_RedIrr\Remodel3.ccf";
                sr_73 = @"S:\US_Scenarios\ScenarioModeling\30%_RedIrr_80%_Seep\Remodel3.ccf";
                sr_74 = @"S:\US_Scenarios\ScenarioModeling\30%Seep\Remodel3.ccf";
                sr_75 = @"S:\US_Scenarios\ScenarioModeling\35%_RedIrr\Remodel3.ccf";
                sr_76 = @"S:\US_Scenarios\ScenarioModeling\40%_RedIrr\Remodel3.ccf";
                sr_77 = @"S:\US_Scenarios\ScenarioModeling\40%Seep\Remodel3.ccf";
                sr_78 = @"S:\US_Scenarios\ScenarioModeling\45%_RedIrr\Remodel3.ccf";
                sr_79 = @"S:\US_Scenarios\ScenarioModeling\5%_AltApp\Remodel3.ccf";
                sr_80 = @"S:\US_Scenarios\ScenarioModeling\5%_FalFld\Remodel3.ccf";
                sr_81 = @"S:\US_Scenarios\ScenarioModeling\5%_RedIrr\Remodel3.ccf";
                sr_82 = @"S:\US_Scenarios\ScenarioModeling\50%_RedIrr\Remodel3.ccf";
                sr_83 = @"S:\US_Scenarios\ScenarioModeling\50%Seep\Remodel3.ccf";
                sr_84 = @"S:\US_Scenarios\ScenarioModeling\60%Seep\Remodel3.ccf";
                sr_85 = @"S:\US_Scenarios\ScenarioModeling\70%Seep\Remodel3.ccf";
                sr_86 = @"S:\US_Scenarios\ScenarioModeling\80%Seep\Remodel3.ccf";
                sr_87 = @"S:\US_Scenarios\ScenarioModeling\90%Seep\Remodel3.ccf";
                sr_88 = @"S:\US_Scenarios\ScenarioModeling\Baseline\Remodel3.ccf";

                #endregion
            }
            else if (region == "Downstream")
            {
                FileNameBase = "DSModel_09";
                EndingTS = 292;

                #region Assigning paths for downstream
                sr_1 = @"S:\DS_Scenarios\ScenarioModeling\10%_AltApp\DSModel_09.ccf";
                sr_2 = @"S:\DS_Scenarios\ScenarioModeling\10%_FalFld\DSModel_09.ccf";
                sr_3 = @"S:\DS_Scenarios\ScenarioModeling\10%_RedIrr\DSModel_09.ccf";
                sr_4 = @"S:\DS_Scenarios\ScenarioModeling\10%Seep\DSModel_09.ccf";
                sr_5 = @"S:\DS_Scenarios\ScenarioModeling\15%_AltApp\DSModel_09.ccf";
                sr_6 = @"S:\DS_Scenarios\ScenarioModeling\15%_FalFld\DSModel_09.ccf";
                sr_7 = @"S:\DS_Scenarios\ScenarioModeling\15%_RedIrr\DSModel_09.ccf";
                sr_8 = @"S:\DS_Scenarios\ScenarioModeling\20%_AltApp\DSModel_09.ccf";
                sr_9 = @"S:\DS_Scenarios\ScenarioModeling\20%_FalFld\DSModel_09.ccf";
                sr_10 = @"S:\DS_Scenarios\ScenarioModeling\20%_RedIrr\DSModel_09.ccf";
                sr_11 = @"S:\DS_Scenarios\ScenarioModeling\20%Seep\DSModel_09.ccf";
                sr_12 = @"S:\DS_Scenarios\ScenarioModeling\25%_AltApp\DSModel_09.ccf";
                sr_13 = @"S:\DS_Scenarios\ScenarioModeling\25%_FalFld\DSModel_09.ccf";
                sr_14 = @"S:\DS_Scenarios\ScenarioModeling\25%_FalFld_20%_RedIrr\DSModel_09.ccf";
                sr_15 = @"S:\DS_Scenarios\ScenarioModeling\25%_FalFld_20%_RedIrr_30%_Seep\DSModel_09.ccf";
                sr_16 = @"S:\DS_Scenarios\ScenarioModeling\25%_FalFld_20%_RedIrr_30%_Seep_Reform_pET\DSModel_09.ccf";
                sr_17 = @"S:\DS_Scenarios\ScenarioModeling\25%_FalFld_20%_RedIrr_50%_Seep\DSModel_09.ccf";
                sr_18 = @"S:\DS_Scenarios\ScenarioModeling\25%_FalFld_20%_RedIrr_50%_Seep_Reform_pET\DSModel_09.ccf";
                sr_19 = @"S:\DS_Scenarios\ScenarioModeling\25%_FalFld_20%_RedIrr_80%_Seep\DSModel_09.ccf";
                sr_20 = @"S:\DS_Scenarios\ScenarioModeling\25%_FalFld_20%_RedIrr_80%_Seep_Reform_pET\DSModel_09.ccf";
                sr_21 = @"S:\DS_Scenarios\ScenarioModeling\25%_FalFld_20%_RedIrr_Reform_pET\DSModel_09.ccf";
                sr_22 = @"S:\DS_Scenarios\ScenarioModeling\25%_FalFld_25%_RedIrr\DSModel_09.ccf";
                sr_23 = @"S:\DS_Scenarios\ScenarioModeling\25%_FalFld_25%_RedIrr_30%_Seep\DSModel_09.ccf";
                sr_24 = @"S:\DS_Scenarios\ScenarioModeling\25%_FalFld_25%_RedIrr_30%_Seep_Reform_pET\DSModel_09.ccf";
                sr_25 = @"S:\DS_Scenarios\ScenarioModeling\25%_FalFld_25%_RedIrr_50%_Seep\DSModel_09.ccf";
                sr_26 = @"S:\DS_Scenarios\ScenarioModeling\25%_FalFld_25%_RedIrr_50%_Seep_Reform_pET\DSModel_09.ccf";
                sr_27 = @"S:\DS_Scenarios\ScenarioModeling\25%_FalFld_25%_RedIrr_80%_Seep\DSModel_09.ccf";
                sr_28 = @"S:\DS_Scenarios\ScenarioModeling\25%_FalFld_25%_RedIrr_80%_Seep_Reform_pET\DSModel_09.ccf";
                sr_29 = @"S:\DS_Scenarios\ScenarioModeling\25%_FalFld_25%_RedIrr_Reform_pET\DSModel_09.ccf";
                sr_30 = @"S:\DS_Scenarios\ScenarioModeling\25%_FalFld_30%_RedIrr\DSModel_09.ccf";
                sr_31 = @"S:\DS_Scenarios\ScenarioModeling\25%_FalFld_30%_RedIrr_30%_Seep\DSModel_09.ccf";
                sr_32 = @"S:\DS_Scenarios\ScenarioModeling\25%_FalFld_30%_RedIrr_30%_Seep_Reform_pET\DSModel_09.ccf";
                sr_33 = @"S:\DS_Scenarios\ScenarioModeling\25%_FalFld_30%_RedIrr_50%_Seep\DSModel_09.ccf";
                sr_34 = @"S:\DS_Scenarios\ScenarioModeling\25%_FalFld_30%_RedIrr_50%_Seep_Reform_pET\DSModel_09.ccf";
                sr_35 = @"S:\DS_Scenarios\ScenarioModeling\25%_FalFld_30%_RedIrr_80%_Seep\DSModel_09.ccf";
                sr_36 = @"S:\DS_Scenarios\ScenarioModeling\25%_FalFld_30%_RedIrr_80%_Seep_Reform_pET\DSModel_09.ccf";
                sr_37 = @"S:\DS_Scenarios\ScenarioModeling\25%_FalFld_30%_RedIrr_Reform_pET\DSModel_09.ccf";
                sr_38 = @"S:\DS_Scenarios\ScenarioModeling\25%_FalFld_35%_RedIrr\DSModel_09.ccf";
                sr_39 = @"S:\DS_Scenarios\ScenarioModeling\25%_FalFld_35%_RedIrr_30%_Seep\DSModel_09.ccf";
                sr_40 = @"S:\DS_Scenarios\ScenarioModeling\25%_FalFld_35%_RedIrr_30%_Seep_Reform_pET\DSModel_09.ccf";
                sr_41 = @"S:\DS_Scenarios\ScenarioModeling\25%_FalFld_35%_RedIrr_50%_Seep\DSModel_09.ccf";
                sr_42 = @"S:\DS_Scenarios\ScenarioModeling\25%_FalFld_35%_RedIrr_50%_Seep_Reform_pET\DSModel_09.ccf";
                sr_43 = @"S:\DS_Scenarios\ScenarioModeling\25%_FalFld_35%_RedIrr_80%_Seep\DSModel_09.ccf";
                sr_44 = @"S:\DS_Scenarios\ScenarioModeling\25%_FalFld_35%_RedIrr_80%_Seep_Reform_pET\DSModel_09.ccf";
                sr_45 = @"S:\DS_Scenarios\ScenarioModeling\25%_FalFld_35%_RedIrr_Reform_pET\DSModel_09.ccf";
                sr_46 = @"S:\DS_Scenarios\ScenarioModeling\25%_FalFld_40%_RedIrr\DSModel_09.ccf";
                sr_47 = @"S:\DS_Scenarios\ScenarioModeling\25%_FalFld_40%_RedIrr_30%_Seep\DSModel_09.ccf";
                sr_48 = @"S:\DS_Scenarios\ScenarioModeling\25%_FalFld_40%_RedIrr_30%_Seep_Reform_pET\DSModel_09.ccf";
                sr_49 = @"S:\DS_Scenarios\ScenarioModeling\25%_FalFld_40%_RedIrr_50%_Seep\DSModel_09.ccf";
                sr_50 = @"S:\DS_Scenarios\ScenarioModeling\25%_FalFld_40%_RedIrr_50%_Seep_Reform_pET\DSModel_09.ccf";
                sr_51 = @"S:\DS_Scenarios\ScenarioModeling\25%_FalFld_40%_RedIrr_80%_Seep\DSModel_09.ccf";
                sr_52 = @"S:\DS_Scenarios\ScenarioModeling\25%_FalFld_40%_RedIrr_80%_Seep_Reform_pET\DSModel_09.ccf";
                sr_53 = @"S:\DS_Scenarios\ScenarioModeling\25%_FalFld_40%_RedIrr_Reform_pET\DSModel_09.ccf";
                sr_54 = @"S:\DS_Scenarios\ScenarioModeling\25%_FalFld_45%_RedIrr\DSModel_09.ccf";
                sr_55 = @"S:\DS_Scenarios\ScenarioModeling\25%_FalFld_45%_RedIrr_30%_Seep\DSModel_09.ccf";
                sr_56 = @"S:\DS_Scenarios\ScenarioModeling\25%_FalFld_45%_RedIrr_30%_Seep_Reform_pET\DSModel_09.ccf";
                sr_57 = @"S:\DS_Scenarios\ScenarioModeling\25%_FalFld_45%_RedIrr_50%_Seep\DSModel_09.ccf";
                sr_58 = @"S:\DS_Scenarios\ScenarioModeling\25%_FalFld_45%_RedIrr_50%_Seep_Reform_pET\DSModel_09.ccf";
                sr_59 = @"S:\DS_Scenarios\ScenarioModeling\25%_FalFld_45%_RedIrr_80%_Seep\DSModel_09.ccf";
                sr_60 = @"S:\DS_Scenarios\ScenarioModeling\25%_FalFld_45%_RedIrr_80%_Seep_Reform_pET\DSModel_09.ccf";
                sr_61 = @"S:\DS_Scenarios\ScenarioModeling\25%_FalFld_45%_RedIrr_Reform_pET\DSModel_09.ccf";
                sr_62 = @"S:\DS_Scenarios\ScenarioModeling\25%_FalFld_50%_RedIrr\DSModel_09.ccf";
                sr_63 = @"S:\DS_Scenarios\ScenarioModeling\25%_FalFld_50%_RedIrr_30%_Seep\DSModel_09.ccf";
                sr_64 = @"S:\DS_Scenarios\ScenarioModeling\25%_FalFld_50%_RedIrr_30%_Seep_Reform_pET\DSModel_09.ccf";
                sr_65 = @"S:\DS_Scenarios\ScenarioModeling\25%_FalFld_50%_RedIrr_50%_Seep\DSModel_09.ccf";
                sr_66 = @"S:\DS_Scenarios\ScenarioModeling\25%_FalFld_50%_RedIrr_50%_Seep_Reform_pET\DSModel_09.ccf";
                sr_67 = @"S:\DS_Scenarios\ScenarioModeling\25%_FalFld_50%_RedIrr_80%_Seep\DSModel_09.ccf";
                sr_68 = @"S:\DS_Scenarios\ScenarioModeling\25%_FalFld_50%_RedIrr_80%_Seep_Reform_pET\DSModel_09.ccf";
                sr_69 = @"S:\DS_Scenarios\ScenarioModeling\25%_FalFld_50%_RedIrr_Reform_pET\DSModel_09.ccf";
                sr_70 = @"S:\DS_Scenarios\ScenarioModeling\25%_FalFld_Reform_pET\DSModel_09.ccf";
                sr_71 = @"S:\DS_Scenarios\ScenarioModeling\25%_RedIrr\DSModel_09.ccf";
                sr_72 = @"S:\DS_Scenarios\ScenarioModeling\30%_RedIrr\DSModel_09.ccf";
                sr_73 = @"S:\DS_Scenarios\ScenarioModeling\30%_RedIrr_80%_Seep\DSModel_09.ccf";
                sr_74 = @"S:\DS_Scenarios\ScenarioModeling\30%Seep\DSModel_09.ccf";
                sr_75 = @"S:\DS_Scenarios\ScenarioModeling\35%_RedIrr\DSModel_09.ccf";
                sr_76 = @"S:\DS_Scenarios\ScenarioModeling\40%_RedIrr\DSModel_09.ccf";
                sr_77 = @"S:\DS_Scenarios\ScenarioModeling\40%Seep\DSModel_09.ccf";
                sr_78 = @"S:\DS_Scenarios\ScenarioModeling\45%_RedIrr\DSModel_09.ccf";
                sr_79 = @"S:\DS_Scenarios\ScenarioModeling\5%_AltApp\DSModel_09.ccf";
                sr_80 = @"S:\DS_Scenarios\ScenarioModeling\5%_FalFld\DSModel_09.ccf";
                sr_81 = @"S:\DS_Scenarios\ScenarioModeling\5%_RedIrr\DSModel_09.ccf";
                sr_82 = @"S:\DS_Scenarios\ScenarioModeling\50%_RedIrr\DSModel_09.ccf";
                sr_83 = @"S:\DS_Scenarios\ScenarioModeling\50%Seep\DSModel_09.ccf";
                sr_84 = @"S:\DS_Scenarios\ScenarioModeling\60%Seep\DSModel_09.ccf";
                sr_85 = @"S:\DS_Scenarios\ScenarioModeling\70%Seep\DSModel_09.ccf";
                sr_86 = @"S:\DS_Scenarios\ScenarioModeling\80%Seep\DSModel_09.ccf";
                sr_87 = @"S:\DS_Scenarios\ScenarioModeling\90%Seep\DSModel_09.ccf";
                sr_88 = @"S:\DS_Scenarios\ScenarioModeling\Baseline\DSModel_09.ccf";
                #endregion
            }
            else
            {
                return;
            }

            RiverFluxVals = new object[EndingTS, 88];

            try
            {
                i = FreeFile();

                FileStream fs;
                string[] m_arr;

                for (int scenario = 1; scenario <= 88; scenario++)
                {

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private int FreeFile()
        {
            throw new NotImplementedException();
        }
    }
}
