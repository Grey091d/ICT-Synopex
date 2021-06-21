using SYNOPEX_ICT.Stored;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SYNOPEX_ICT.ViewModels
{
    class ScreenWorkVM : BaseVM
    {
        public int m_lAxisCounts = 0;                               // Khai báo và khởi tạo số lượng trục có thể điều khiển
        private int m_lAxisNo = 0;                                  // Khai báo và khởi tạo số trục được điều khiển
        public uint m_uModuleID = 0;                                // Khai báo và khởi tạo mô-đun I / O của trục được điều khiển
        public uint m_lMoveMultiAxesCount = 0;                      // Khai báo và khởi tạo số lượng trục được dẫn động nhiều trục   
        public int[] m_lMoveMultiAxes = { -1, -1, -1, -1 };         // Khai báo và khởi tạo số mảng trục được điều khiển theo nhiều trục...
        public int m_lBoardNo = 0, m_lModulePos = 0;

        public double[] m_dOldCmdPos = { 0.0, 0.0, 0.0, 0.0 };      // tmDisplay Trước đó để sử dụng trong Command Position	
        public double[] m_dOldActPos = { 0.0, 0.0, 0.0, 0.0 };      // tmDisplay Trước đó để sử dụng trong Actual Position
        public double[] m_dOldCmdVel = { 0.0, 0.0, 0.0, 0.0 };      // tmDisplay Trước đó để sử dụng trong Command Velocity
        public ScreenWorkVM(NavigationStore navigationStore)
        {

        }
        public ScreenWorkVM()
        {

        }

        public void UpdateState()
        {
            //TextBox[] MovePos = new TextBox[4];
            //MovePos[0] = edtMovePos00; MovePos[1] = edtMovePos01; MovePos[2] = edtMovePos02; MovePos[3] = edtMovePos03;
            //TextBox[] MoveVel = new TextBox[4];
            //MoveVel[0] = edtMoveVel00; MoveVel[1] = edtMoveVel01; MoveVel[2] = edtMoveVel02; MoveVel[3] = edtMoveVel03;
            //TextBox[] MoveAcc = new TextBox[4];
            //MoveAcc[0] = edtMoveAcc00; MoveAcc[1] = edtMoveAcc01; MoveAcc[2] = edtMoveAcc02; MoveAcc[3] = edtMoveAcc03;
            //TextBox[] MoveDec = new TextBox[4];
            //MoveDec[0] = edtMoveDec00; MoveDec[1] = edtMoveDec01; MoveDec[2] = edtMoveDec02; MoveDec[3] = edtMoveDec03;
            //TextBox[] JogVel = new TextBox[4];
            //JogVel[0] = edtJogVel00; JogVel[1] = edtJogVel01; JogVel[2] = edtJogVel02; JogVel[3] = edtJogVel03;
            //TextBox[] JogAcc = new TextBox[4];
            //JogAcc[0] = edtJogAcc00; JogAcc[1] = edtJogAcc01; JogAcc[2] = edtJogAcc02; JogAcc[3] = edtJogAcc03;
            //TextBox[] JogDec = new TextBox[4];
            //JogDec[0] = edtJogDec00; JogDec[1] = edtJogDec01; JogDec[2] = edtJogDec02; JogDec[3] = edtJogDec03;
            //TextBox[] LinePos = new TextBox[4];
            //LinePos[0] = edtLinePos00; LinePos[1] = edtLinePos01; LinePos[2] = edtLinePos02; LinePos[3] = edtLinePos03;

            //CheckBox[] chkMoveMultiAxes = new CheckBox[4];
            //chkMoveMultiAxes[0] = chkAxis00; chkMoveMultiAxes[1] = chkAxis01;
            //chkMoveMultiAxes[2] = chkAxis02; chkMoveMultiAxes[3] = chkAxis03;

            bool bSelectCheck, bEmptyCheck, bAllCheck;
            String strData;
            uint duOnOff = 0;
            uint lCount;
            int lFirstAxisNo = 0;

            m_lMoveMultiAxesCount = 0;
            bSelectCheck = false;
            bEmptyCheck = false;

            //++ 지정한 축의 정보를 반환합니다.
            // [INFO] 여러개의 정보를 읽는 함수 사용시 불필요한 정보는 NULL(0)을 입력하면 됩니다.
            CAXM.AxmInfoGetAxis(m_lAxisNo, ref m_lBoardNo, ref m_lModulePos, ref m_uModuleID);
            //++ 지정한 보드/모듈의 첫번째 축 번호를 반환합니다.
            CAXM.AxmInfoGetFirstAxisNo(m_lBoardNo, m_lModulePos, ref lFirstAxisNo);

            for (lCount = 0; lCount < 4; lCount++)
            {
                //++ 지정한 축이 제어가 가능한 상태인지 반환합니다.
                if (CAXM.AxmInfoGetAxisStatus(lFirstAxisNo) == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                {
                    strData = string.Format("Axis{0:d2}", lFirstAxisNo);
                    //chkMoveMultiAxes[lCount].Enabled = true;

                    //bSelectCheck = chkMoveMultiAxes[lCount].Checked;
                    bEmptyCheck |= bSelectCheck;

                    if (bSelectCheck == true)
                        m_lMoveMultiAxes[m_lMoveMultiAxesCount++] = lFirstAxisNo;

                    //MovePos[lCount].Enabled = bSelectCheck;
                    //MoveVel[lCount].Enabled = bSelectCheck;
                    //MoveAcc[lCount].Enabled = bSelectCheck;
                    //MoveDec[lCount].Enabled = bSelectCheck;

                    //JogVel[lCount].Enabled = bSelectCheck;
                    //JogAcc[lCount].Enabled = bSelectCheck;
                    //JogDec[lCount].Enabled = bSelectCheck;

                    //LinePos[lCount].Enabled = bSelectCheck;
                }
                else
                {
                    m_lMoveMultiAxes[lCount] = -1;
                    strData = string.Format("Axis --");

                    //MovePos[lCount].Enabled = false;
                    //MoveVel[lCount].Enabled = false;
                    //MoveAcc[lCount].Enabled = false;
                    //MoveDec[lCount].Enabled = false;

                    //JogVel[lCount].Enabled = false;
                    //JogAcc[lCount].Enabled = false;
                    //JogDec[lCount].Enabled = false;

                    //LinePos[lCount].Enabled = false;
                }
                lFirstAxisNo++;
                //chkMoveMultiAxes[lCount].Text = strData;
            }

            //edtLineVel.Enabled = bEmptyCheck;
            //edtLineAcc.Enabled = bEmptyCheck;
            //edtLineDec.Enabled = bEmptyCheck;

            //btnJogP.Enabled = bEmptyCheck;
            //btnJogN.Enabled = bEmptyCheck;

            //btnLineP.Enabled = bEmptyCheck;
            //btnLineN.Enabled = bEmptyCheck;

            //btnPosMove.Enabled = bEmptyCheck;
            //btnPosStop.Enabled = bEmptyCheck;

            //btnPosClear.Enabled = bEmptyCheck;
            //chkMoveBlock.Enabled = bEmptyCheck;
            //chkServoOn.Enabled = bEmptyCheck;

            bAllCheck = false;
            for (lCount = 0; lCount < m_lMoveMultiAxesCount; lCount++)
            {
                //++ 지정한 축의 서보온 상태를 반환합니다.
                CAXM.AxmSignalIsServoOn(m_lMoveMultiAxes[lCount], ref duOnOff);
                // 선택된 보간축들이 모두 서보온 되어있을 때 TRUE 
                bAllCheck &= Convert.ToBoolean(duOnOff);
            }
            //chkServoOn.Checked = bAllCheck;
        }

        public void AddAxisInfo()
        {
            String strAxis = "";

            //++ Trả về tổng số trục chuyển động hợp lệ.
            CAXM.AxmInfoGetAxisCount(ref m_lAxisCounts);
            m_lAxisNo = 0;
            //++ Trả về thông tin trên trục được chỉ định.
            // [INFO] Khi sử dụng một hàm đọc nhiều thông tin, hãy nhập NULL (0) cho những thông tin không cần thiết.
            CAXM.AxmInfoGetAxis(m_lAxisNo, ref m_lBoardNo, ref m_lModulePos, ref m_uModuleID);
            for (int i = 0; i < m_lAxisCounts; i++)
            {
                switch (m_uModuleID)
                {
                    //++ Trả về thông tin trên trục được chỉ định.
                    // [INFO] Khi sử dụng một hàm đọc nhiều thông tin, hãy nhập NULL (0) cho những thông tin không cần thiết.
                    case (uint)AXT_MODULE.AXT_SMC_4V04: strAxis = String.Format("{0:0}-(AXT_SMC_4V04)", i); break;
                    case (uint)AXT_MODULE.AXT_SMC_R1V04: strAxis = String.Format("{0:0}-[AXT_SMC_R1V04]", i); break;
                    case (uint)AXT_MODULE.AXT_SMC_2V04: strAxis = String.Format("{0:0}-[AXT_SMC_2V04]", i); break;
                    case (uint)AXT_MODULE.AXT_SMC_R1V04MLIIPM: strAxis = String.Format("{0:0}-[AXT_SMC_R1V04MLIIPM]", i); break;
                    case (uint)AXT_MODULE.AXT_SMC_R1V04PM2Q: strAxis = String.Format("{0:0}-[AXT_SMC_R1V04PM2Q]", i); break;
                    case (uint)AXT_MODULE.AXT_SMC_R1V04PM2QE: strAxis = String.Format("{0:0}-[AXT_SMC_R1V04PM2QE]", i); break;
                    case (uint)AXT_MODULE.AXT_SMC_R1V04MLIIIPM: strAxis = String.Format("{0:0}-(AXT_SMC_R1V04MLIIIPM)", i); break;
                    case (uint)AXT_MODULE.AXT_SMC_R1V04MLIISV: strAxis = String.Format("{0:0}-[AXT_SMC_R1V04MLIISV]", i); break;
                    case (uint)AXT_MODULE.AXT_SMC_R1V04A5: strAxis = String.Format("{0:0}-[AXT_SMC_R1V04A4]", i); break;
                    case (uint)AXT_MODULE.AXT_SMC_R1V04A4: strAxis = String.Format("{0:0}-[AXT_SMC_R1V04MLIICL]", i); break;
                    case (uint)AXT_MODULE.AXT_SMC_R1V04SIIIHMIV: strAxis = String.Format("{0:0}-[AXT_SMC_R1V04SIIIHMIV]", i); break;
                    case (uint)AXT_MODULE.AXT_SMC_R1V04SIIIHMIV_R: strAxis = String.Format("{0:0}-[AXT_SMC_R1V04SIIIHMIV_R]", i); break;
                    case (uint)AXT_MODULE.AXT_SMC_R1V04MLIIISV: strAxis = String.Format("{0:0}-[AXT_SMC_R1V04MLIIISV]", i); break;
                    case (uint)AXT_MODULE.AXT_SMC_R1V04MLIIISV_MD: strAxis = String.Format("{0:0}-[AXT_SMC_R1V04MLIIISV_MD]", i); break;
                    case (uint)AXT_MODULE.AXT_SMC_R1V04MLIIIS7S: strAxis = String.Format("{0:0}-[AXT_SMC_R1V04MLIIIS7S]", i); break;
                    case (uint)AXT_MODULE.AXT_SMC_R1V04MLIIIS7W: strAxis = String.Format("{0:0}-[AXT_SMC_R1V04MLIIIS7W]", i); break;
                    default: strAxis = String.Format("{0:00}-[Unknown]", i); break;
                }
                //cboSelAxis.Items.Add(strAxis);
            }
            InitControl();      // Control Đăng ký các biến và thiết lập cài đặt ban đầu.
        }

        private void InitControl()
        {
            uint lCount = 0;

            //cboSelAxis.SelectedIndex = m_lAxisNo;

            //TextBox[] MovePos = new TextBox[4];
            //MovePos[0] = edtMovePos00; MovePos[1] = edtMovePos01; MovePos[2] = edtMovePos02; MovePos[3] = edtMovePos03;
            //TextBox[] MoveVel = new TextBox[4];
            //MoveVel[0] = edtMoveVel00; MoveVel[1] = edtMoveVel01; MoveVel[2] = edtMoveVel02; MoveVel[3] = edtMoveVel03;
            //TextBox[] MoveAcc = new TextBox[4];
            //MoveAcc[0] = edtMoveAcc00; MoveAcc[1] = edtMoveAcc01; MoveAcc[2] = edtMoveAcc02; MoveAcc[3] = edtMoveAcc03;
            //TextBox[] MoveDec = new TextBox[4];
            //MoveDec[0] = edtMoveDec00; MoveDec[1] = edtMoveDec01; MoveDec[2] = edtMoveDec02; MoveDec[3] = edtMoveDec03;
            //TextBox[] JogVel = new TextBox[4];
            //JogVel[0] = edtJogVel00; JogVel[1] = edtJogVel01; JogVel[2] = edtJogVel02; JogVel[3] = edtJogVel03;
            //TextBox[] JogAcc = new TextBox[4];
            //JogAcc[0] = edtJogAcc00; JogAcc[1] = edtJogAcc01; JogAcc[2] = edtJogAcc02; JogAcc[3] = edtJogAcc03;
            //TextBox[] JogDec = new TextBox[4];
            //JogDec[0] = edtJogDec00; JogDec[1] = edtJogDec01; JogDec[2] = edtJogDec02; JogDec[3] = edtJogDec03;
            //TextBox[] LinePos = new TextBox[4];
            //LinePos[0] = edtLinePos00; LinePos[1] = edtLinePos01; LinePos[2] = edtLinePos02; LinePos[3] = edtLinePos03;

            //CheckBox[] chkMoveMultiAxes = new CheckBox[4];
            //chkMoveMultiAxes[0] = chkAxis00; chkMoveMultiAxes[1] = chkAxis01;
            //chkMoveMultiAxes[2] = chkAxis02; chkMoveMultiAxes[3] = chkAxis03;

            // Edit Control에 초기값 설정
            for (lCount = 0; lCount < 4; lCount++)
            {
                //MovePos[lCount].Text = "100.000";
                //MoveVel[lCount].Text = "100.000";
                //MoveAcc[lCount].Text = "400.000";
                //MoveDec[lCount].Text = "400.000";
                //JogVel[lCount].Text = "100.000";
                //JogAcc[lCount].Text = "400.000";
                //JogDec[lCount].Text = "400.000";
                //LinePos[lCount].Text = "100.000";
            }

            //edtLineVel.Text = "100.000";
            //edtLineAcc.Text = "400.000";
            //edtLineDec.Text = "200.000";
        }

        public void initLibrary()
        {
            String szFilePath = "C:\\Program Files\\EzSoftware RM\\EzSoftware\\MotionDefault.mot";
            //++ AXL(AjineXtek Library)Bật và khởi tạo các bảng được gắn kết.
            if (CAXL.AxlOpen(7) != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS) MessageBox.Show("Intialize Fail..!!");
            //++ Thay đổi hàng loạt và áp dụng các giá trị cài đặt của bảng chuyển động với các giá trị cài đặt của tệp Mot được chỉ định.
            if (CAXM.AxmMotLoadParaAll(szFilePath) != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS) MessageBox.Show("Mot File Not Found.");
        }
    }
}
