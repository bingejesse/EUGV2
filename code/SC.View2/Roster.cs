using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SC.View2
{
    static class Roster
    {
        public const string Home = "Home";

        #region 快递员
        public const string P_ControlPanel = "PostmanControlPanel";

        public const string P_D_Verify = "PostmanVerify";
        public const string P_D_ChooseBox = "PostmanChooseBox";
        public const string P_D_DeliverPG = "PostmanDeliverPG";
        public const string P_D_EntryPGInfo = "PostmanEntryPGInfo";
        public const string P_D_FinishWork = "PostmanFinishWork";
        public const string P_D_PGVerify = "PostmanPGVerify";
        public const string P_D_Cancel = "PostmanCancel";
        public const string P_D_CancelTask = "PostmanCancelTask";

        public const string P_T_Verify = "PostmanVerify";
        public const string P_T_EntryPGInfo = "PostmanTBEntryPGInfo";
        public const string P_T_FinishWork = "PostmanTBFinishWork";

        public const string P_S_Verify = "PostmanVerify";
        public const string P_S_PGDelivered = "PostmanSPGDelivered";

        public const string P_R_PGRegister = "PostmanRegister";
        #endregion

        #region 收件人
        public const string C_ControlPanel = "CustomerControlPanel";

        public const string C_T_Verify = "CustomerTBVerify";
        public const string C_T_FinishWork = "CustomerTBFinishWork";

        public const string C_S_EntryPGInfo = "CustomerSEntryPGInfo";

        public const string C_S_PGSearched = "CustomerPGSearched";
        #endregion

        #region 代理人
        public const string A_Verify = "AdminVerify";
        public const string A_P_EntryBoxCode = "AdminProxyEntryBoxCode";
        public const string A_P_FinishWork = "AdminProxyFinishWork";
        public const string A_ControlPanel = "AdministratorControlPanel";
        #endregion


    }
}
