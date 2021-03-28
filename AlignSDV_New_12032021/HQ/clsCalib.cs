using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HalconDotNet;

namespace HQ
{

    public static class clsCalib
    {

        static HTuple CalibDataID = new HTuple();
        static HTuple CameraParam = new HTuple();
        static HTuple arrPointRobotX = new HTuple();
        static HTuple arrPointRobotY = new HTuple();
        static HTuple arrPointRobotZ = new HTuple();
        static HTuple arrPointVisionX = new HTuple();
        static HTuple arrPointVisionY = new HTuple();
        // Handeye 11 point


        public static HTuple InitCalib(string TypeCam, string TypeCalib, double FocalLength, double Kappa, double CellWidth, double CellHeight, double Sx, double Sy, double Width, double Height, string Desc)
        {
            try
            {
                CameraParam = new HTuple(TypeCam, FocalLength, Kappa, CellWidth, CellHeight, Sx, Sy, Width, Height);
                HOperatorSet.CreateCalibData(TypeCalib, 1, 1, out CalibDataID);
                HOperatorSet.SetCalibDataCamParam(CalibDataID, "all", new HTuple(), CameraParam);
                HOperatorSet.SetCalibDataCalibObject(CalibDataID, 0, Desc);
                return CalibDataID;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }
        public static int FindCalib(HObject Image, HWindow _windown, int i)
        {
            try
            {
                _windown.DispObj(Image);
                HOperatorSet.FindCalibObject(Image, CalibDataID, 0, 0, i, new HTuple(), new HTuple());
                HOperatorSet.GetCalibDataObservContours(out HObject Contours, CalibDataID, "marks", 0, 0, i);
                HOperatorSet.GetCalibDataObservPose(CalibDataID, 0, 0, i, out HTuple CameraPose);
                HOperatorSet.WritePose(CameraPose, Application.StartupPath + "/calibration/" + "CamPose" + i + ".dat");
                HObject CaltabPoint = new HObject(Contours);
                _windown.SetColor("green");
                _windown.DispObj(CaltabPoint);
                Contours.Dispose();
                ShowOrigin(_windown, CameraParam, CameraPose, 0.01);
                return 2;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public static HTuple Finally()
        {
            try
            {
                HOperatorSet.CalibrateCameras(CalibDataID, out HTuple Error);
                HOperatorSet.GetCalibData(CalibDataID, "camera", 0, "params", out HTuple DataValue);
                HOperatorSet.WriteCamPar(DataValue, Application.StartupPath + "/calibration/" + "CamPar.dat");
                HOperatorSet.WriteCalibData(CalibDataID, Application.StartupPath + "/calibration/" + "calibration.ccd");
                HOperatorSet.GetCalibData(CalibDataID, "calib_obj_pose", new HTuple(0, 0), "pose", out HTuple Pose);
                return Error;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public static HTuple HandEyeFinally(HTuple _CameraParam)
        {


            HTuple[] dataError = new HTuple[] { "Error", "Error" };
            try
            {
                HTuple data01 = new HTuple();
                HTuple data02 = new HTuple();

                HOperatorSet.WriteTuple(arrPointRobotX, Application.StartupPath + "/arrPoint/X_Robot.tup");
                HOperatorSet.WriteTuple(arrPointRobotY, Application.StartupPath + "/arrPoint/Y_Robot.tup");
                HOperatorSet.WriteTuple(arrPointRobotZ, Application.StartupPath + "/arrPoint/Z_Robot.tup");

                HOperatorSet.WriteTuple(arrPointVisionX, Application.StartupPath + "/arrPoint/X_Vision.tup");
                HOperatorSet.WriteTuple(arrPointVisionY, Application.StartupPath + "/arrPoint/Y_Vision.tup");

                HDevProcedure _handeye = new HDevProcedure("calibrate_hand_eye_scara_stationary_cam_approx2");
                HDevProcedureCall _handeyecall = new HDevProcedureCall(_handeye);
                _handeyecall.SetInputCtrlParamTuple("CameraParam", _CameraParam);
                _handeyecall.SetInputCtrlParamTuple("CalibrationPointsRow", arrPointVisionX);
                _handeyecall.SetInputCtrlParamTuple("CalibrationPointsColumn", arrPointVisionY);
                _handeyecall.SetInputCtrlParamTuple("CalibrationRobotX", arrPointRobotX);
                _handeyecall.SetInputCtrlParamTuple("CalibrationRobotY", arrPointRobotY);
                _handeyecall.SetInputCtrlParamTuple("CalibrationRobotZ", arrPointRobotZ);
                _handeyecall.Execute();
                data01 = _handeyecall.GetOutputCtrlParamTuple("CamInBasePose");
                data02 = _handeyecall.GetOutputCtrlParamTuple("CPInCamPose");
                HOperatorSet.WritePose(data01, Application.StartupPath + "/PoseAlign/CamInBasePose.dat");
                HOperatorSet.WritePose(data02, Application.StartupPath + "/PoseAlign/CPInCamPose.dat");

                //HOperatorSet.CalibrateHandEye(CalibDataID, out HTuple Errors);
                //HOperatorSet.GetCalibData(CalibDataID, "camera", 0, "base_in_cam_pose", out HTuple BaseInCamPose);
                //HOperatorSet.WritePose(BaseInCamPose, Application.StartupPath + "/hand_eye/" + "Cam_H_Tool.dat");
                return 1;
            }
            catch (Exception ex)
            {
                return dataError;
            }
        }
        public static int Handeye(HTuple X_R, HTuple Y_R, HTuple Z_R, HTuple RX_R, HTuple RY_R, HTuple RZ_R, HTuple X_V, HTuple Y_V, int i)
        {
            try
            {
                // Lay toa do robot tu PLC
                HOperatorSet.TupleConcat(arrPointRobotX, X_R, out arrPointRobotX);
                HOperatorSet.TupleConcat(arrPointRobotY, Y_R, out arrPointRobotY);
                HOperatorSet.TupleConcat(arrPointRobotZ, Z_R, out arrPointRobotZ);
                HOperatorSet.TupleConcat(arrPointVisionX, X_V, out arrPointVisionX);
                HOperatorSet.TupleConcat(arrPointVisionY, Y_V, out arrPointVisionY);


                //arrPointRobotX[i] = X_R;
                //arrPointRobotY[i] = Y_R;
                //arrPointRobotZ[i] = Z_R;
                ////
                //arrPointVisionX[i] = X_V;
                //arrPointVisionY[i] = Y_V;

                //HOperatorSet.CreatePose(X_R, Y_R, Z_R, RX_R, RY_R, RZ_R, "Rp+T", "gba", "point", out HTuple ToolinBasePose);
                //HOperatorSet.WritePose(ToolinBasePose, Application.StartupPath + "/calibration/" + "ToolPose" + i + ".dat");
                //HOperatorSet.SetCalibData(CalibDataID, "tool", i, "tool_in_base_pose", ToolinBasePose);

                return 1;
            }

            catch (Exception)
            {
                return 0;
            }

        }
        public static int ShowOrigin(HWindow _windown, HTuple CamParam, HTuple Pose, HTuple Length)
        {
            try
            {
                // Convert to pose to a transformation matrix
                HOperatorSet.PoseToHomMat3d(Pose, out HTuple TransWorld2Cam);
                // Project the world origin into the image
                HOperatorSet.AffineTransPoint3d(TransWorld2Cam, 0, 0, 0, out HTuple OrigCamX, out HTuple OrigCamY, out HTuple OrigCamZ);
                HOperatorSet.Project3dPoint(OrigCamX, OrigCamY, OrigCamZ, CamParam, out HTuple Row0, out HTuple Column0);
                //Project the coordinate axes into the image
                HOperatorSet.AffineTransPoint3d(TransWorld2Cam, Length, 0, 0, out HTuple X, out HTuple Y, out HTuple Z);
                HOperatorSet.Project3dPoint(X, Y, Z, CamParam, out HTuple RowAxX, out HTuple ColumnAxX);
                HOperatorSet.AffineTransPoint3d(TransWorld2Cam, 0, Length, 0, out X, out Y, out Z);
                HOperatorSet.Project3dPoint(X, Y, Z, CamParam, out HTuple RowAxY, out HTuple ColumnAxY);
                HOperatorSet.AffineTransPoint3d(TransWorld2Cam, 0, 0, Length, out X, out Y, out Z);
                HOperatorSet.Project3dPoint(X, Y, Z, CamParam, out HTuple RowAxZ, out HTuple ColumnAxZ);
                //Generate an XLD contour for each axis
                HOperatorSet.DistancePp(new HTuple(Row0, Row0, Row0), new HTuple(Column0, Column0, Column0), new HTuple(RowAxX, RowAxY, RowAxZ), new HTuple(ColumnAxX, ColumnAxY, ColumnAxZ), out HTuple Distance);
                double HeadLength = new HTuple(new HTuple(5.0), Distance.TupleMax() / 12.0).TupleMax();
                //Init
                HOperatorSet.GenEmptyObj(out HObject Arrow);
                // Calculate auxiliary variables.
                HTuple DR = 1.0 * (new HTuple(RowAxX, RowAxY, RowAxZ) - new HTuple(Row0, Row0, Row0)) / Distance;
                HTuple DC = 1.0 * (new HTuple(ColumnAxX, ColumnAxY, ColumnAxZ) - new HTuple(Column0, Column0, Column0)) / Distance;
                HTuple Row2 = new HTuple(RowAxX, RowAxY, RowAxZ);
                HTuple Column2 = new HTuple(ColumnAxX, ColumnAxY, ColumnAxZ);
                HTuple HalfHeadWidth = HeadLength / 2.0;
                //Calculate end points of the arrow head.
                HTuple RowP1 = new HTuple(Row0, Row0, Row0) + (Distance - HeadLength) * DR + HalfHeadWidth * DC;
                HTuple ColP1 = new HTuple(Column0, Column0, Column0) + (Distance - HeadLength) * DC - HalfHeadWidth * DR;
                HTuple RowP2 = new HTuple(Row0, Row0, Row0) + (Distance - HeadLength) * DR - HalfHeadWidth * DC;
                HTuple ColP2 = new HTuple(Column0, Column0, Column0) + (Distance - HeadLength) * DC + HalfHeadWidth * DR;
                //Finally create output XLD contour for each input point pair
                HObject TempArrow = new HObject();
                for (int i = 0; i < Distance.Length; i++)
                {
                    if (Distance[i] == (-1.0))
                    //Create_ single points for arrows with identical start and end point
                    {
                        HOperatorSet.GenContourPolygonXld(out TempArrow, Row0, Column0);
                    }

                    else
                    {
                        HOperatorSet.GenContourPolygonXld(out TempArrow, new HTuple(Row0, Row2[i], RowP1[i], Row2[i], RowP2[i], Row2[i]), new HTuple(Column0, Column2[i], ColP1[i], Column2[i], ColP2[i], Column2[i]));

                    }
                    //Create arrow contour
                    HOperatorSet.ConcatObj(Arrow, TempArrow, out Arrow);
                }
                //Display coordinate system
                _windown.SetColored(12);
                HOperatorSet.DispXld(Arrow, _windown);
                HOperatorSet.GetRgb(_windown, out HTuple Red, out HTuple Green, out HTuple Blue);
                HOperatorSet.SetRgb(_windown, Red[0], Green[0], Blue[0]);
                HOperatorSet.SetTposition(_windown, RowAxX + 3, ColumnAxX + 3);
                HOperatorSet.WriteString(_windown, "X");
                HOperatorSet.SetRgb(_windown, Red[1 % Red.Length], Green[1 % Green.Length], Blue[1 % Blue.Length]);
                HOperatorSet.SetTposition(_windown, RowAxY + 3, ColumnAxY + 3);
                HOperatorSet.WriteString(_windown, "Y");
                HOperatorSet.SetRgb(_windown, Red[2 % Red.Length], Green[2 % Green.Length], Blue[2 % Blue.Length]);
                HOperatorSet.SetTposition(_windown, RowAxZ + 3, ColumnAxZ + 3);
                HOperatorSet.WriteString(_windown, "Z");
                HOperatorSet.SetRgb(_windown, Red, Green, Blue);
                return 4;
            }
            catch (Exception)
            {
                return 0;
            }

        }

        //---------------------//
        #region Calib Handeye 11 point
        public static result handeye11point(HTuple lst_row, HTuple lst_col, HTuple lst_the, HTuple lst_robot_x, HTuple lst_robot_y)
        {
            //HDevEngine _procderduce = new HDevEngine();
            //string path_Procerduce = Application.StartupPath + "/HalconProcerduce";
            //_procderduce.SetProcedurePath(path_Procerduce);
            result rs = new result();
            try
            {
                HTuple HomMat_ImgtoWorld = new HTuple();
                HTuple HomMat_WorldtoImg = new HTuple();
                /// Set procedure for handeye program
                HDevProcedure procedure_handeye = new HDevProcedure("handeye_stationary_camera");
                HDevProcedureCall procedure_handeye_call = new HDevProcedureCall(procedure_handeye);
                procedure_handeye_call.SetInputCtrlParamTuple("listRow_Img", lst_row);
                procedure_handeye_call.SetInputCtrlParamTuple("listCol_Img", lst_col);
                procedure_handeye_call.SetInputCtrlParamTuple("listAgl_Img", lst_the);
                procedure_handeye_call.SetInputCtrlParamTuple("listX_Robot", lst_robot_x);
                procedure_handeye_call.SetInputCtrlParamTuple("listY_Robot", lst_robot_y);
                procedure_handeye_call.Execute();
                /// Process procedure and read result from out data
                HomMat_ImgtoWorld = procedure_handeye_call.GetOutputCtrlParamTuple("HomMat_ImgtoWorld");
                HomMat_WorldtoImg = procedure_handeye_call.GetOutputCtrlParamTuple("HomMat_WorldtoImg");
                rs.TCP_to_Tool = procedure_handeye_call.GetOutputCtrlParamTuple("TCP_to_Tool");
                rs.Tool_to_TCP = procedure_handeye_call.GetOutputCtrlParamTuple("Tool_to_TCP");
                rs.Agl_Master = procedure_handeye_call.GetOutputCtrlParamTuple("thetaGet");
                rs.HomMat_ImgtoWorld = HomMat_ImgtoWorld;
                rs.HomMat_WorldtoImg = HomMat_WorldtoImg;
            }
            catch (Exception ex)
            {

            }
            return rs;

        }

        #endregion
        //---------------------//
        #region Create origin from region
        public static result create_origin(HObject Img, HObject Region_Binary, HObject Region_First, HObject Region_Second, HTuple HomMat2D_TransRegion)
        {
            result rs = new result();
            HTuple RowProj = 0;
            HTuple ColProj = 0;
            HTuple Angle_ = 0;

            //Input
            HDevProcedure getOrigin = new HDevProcedure("create_origin_from_region");
            HDevProcedureCall getOriginCall = new HDevProcedureCall(getOrigin);
            getOriginCall.SetInputIconicParamObject("Image", Img);
            getOriginCall.SetInputIconicParamObject("Region_Binary", Region_Binary);
            getOriginCall.SetInputIconicParamObject("Region_First", Region_First);
            getOriginCall.SetInputIconicParamObject("Region_Second", Region_Second);
            getOriginCall.SetInputCtrlParamTuple("HomMat2D_TransRegion", HomMat2D_TransRegion);
            getOriginCall.SetInputCtrlParamTuple("showOrigin", "true");

            getOriginCall.Execute();

            //Output
            RowProj = getOriginCall.GetOutputCtrlParamTuple("RowProj");
            ColProj = getOriginCall.GetOutputCtrlParamTuple("ColProj");
            Angle_ = getOriginCall.GetOutputCtrlParamTuple("Angle");

            rs.RowProj = RowProj;
            rs.ColProj = ColProj;
            rs.Angle_ = Angle_;
            return rs;
        }
        #endregion
        //--------------------//
        #region Find shape model
        public static result findshapemodle(HObject newimg, HTuple ModelID , HWindow _window)
        {
            result rs = new result();
            rs.result_process = "OK";
            try
            {    
                HOperatorSet.FindShapeModel(newimg, ModelID, -0.39, 0.79, 0.5, 1, 0.3, "least_squares", new HTuple(4, -2), 0.9, out HTuple Row, out HTuple Column, out HTuple Angle, out HTuple Score);
                HOperatorSet.VectorAngleToRigid(0, 0, 0, Row[0], Column[0], Angle[0], out HTuple HomMat2D);
                HOperatorSet.GetShapeModelContours(out HObject ModelContour, ModelID, 1);
                HOperatorSet.AffineTransContourXld(ModelContour, out HObject shapemodel_affined, HomMat2D);
                HOperatorSet.GenCrossContourXld(out HObject cross, Row[0], Column[0], 20, 90);
                _window.DispObj(shapemodel_affined);
                // Get list data for shape model
                rs.shapemodel_affined = shapemodel_affined;
                rs.lst_cordinate_shapemodel.Add(Row[0]);
                rs.lst_cordinate_shapemodel.Add(Column[0]);
                rs.lst_cordinate_shapemodel.Add(Angle[0]);
                rs.lst_cordinate_shapemodel.Add(Score[0]);
            }
            catch (Exception)
            {
                rs.result_process = "NG";
            }
            return rs;
        }
        #endregion
        //--------------------//
        #region
        //public static result masterpoint_robot(HTuple  , HTuple x, HTuple y, HTuple agl)
        //{
        //    result rsl = new result();
        //    HOperatorSet.CreatePose(x, y, 0, 0, 0, agl, out );

        //    return rsl;
        //}
        #endregion


    }

    ///// Result All
    public class result
    {
        public string result_process = "OK";

        public HTuple HomMat_ImgtoWorld = new HTuple();
        public HTuple HomMat_WorldtoImg = new HTuple();
        public HTuple Agl_Master = new HTuple();
        // Origin
        public HTuple RowProj = new HTuple();
        public HTuple ColProj = new HTuple();
        public HTuple Angle_ = new HTuple();
        // Find shape model
        public HObject shapemodel_affined = new HObject();
        public List<HTuple> lst_cordinate_shapemodel =  new List<HTuple>();
        //Handeye
        public HTuple TCP_to_Tool = new HTuple();
        public HTuple Tool_to_TCP = new HTuple();
    }
    public class resultOrigin
    {

    }

}