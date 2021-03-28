using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HQ
{
    public static class clsPlc
    {
        
        public static HTuple  RecDataFromPLC(HTuple Data_Type, HTuple Dxxx, HTuple lenght, HTuple socket)
        {
            HTuple data = -1;
            try
            {
                HDevProcedure getDataPlc = new HDevProcedure("Melsoft_3E_Revc");
                HDevProcedureCall getDataPlcCall = new HDevProcedureCall(getDataPlc);
                //_getDataPLC.SetInputCtrlParamTuple(["String","Destination","Lenght","Socket"],)
                getDataPlcCall.SetInputCtrlParamTuple("Data_Type", Data_Type);
                getDataPlcCall.SetInputCtrlParamTuple("Destination", Dxxx);
                getDataPlcCall.SetInputCtrlParamTuple("Lenght", lenght);
                getDataPlcCall.SetInputCtrlParamTuple("Socket", socket);
                getDataPlcCall.Execute();
                data = getDataPlcCall.GetOutputCtrlParamTuple("Data_Tuple");
            }
            catch (Exception ex)
            {
                data = "Error";
            }
            return data;
        }
        public static HTuple SendDataFromPLC(HTuple Data_Type, HTuple Data_Send, HTuple Dxxx, HTuple socket)
        {
            HTuple data = -1;
            try
            {
                HDevProcedure setDataPlc = new HDevProcedure("Melsoft_3E_Send");
                HDevProcedureCall setDataPlcCall = new HDevProcedureCall(setDataPlc);
                setDataPlcCall.SetInputCtrlParamTuple("Data_Type", Data_Type);
                setDataPlcCall.SetInputCtrlParamTuple("Data_Tuple", Data_Send);
                setDataPlcCall.SetInputCtrlParamTuple("Destination", Dxxx);
                setDataPlcCall.SetInputCtrlParamTuple("Socket", socket);
                setDataPlcCall.Execute();
                data = setDataPlcCall.GetOutputCtrlParamTuple("CCode");
            }
            catch (Exception ex)
            {
                data = "Error";
            }

            return data;

        }
        public static HTuple GetBitFromPLC(HTuple Dxxx, HTuple GetIndexBit, HTuple socket)
        {
            HTuple data = -1;
            try
            {
                HDevProcedure getDataPlc = new HDevProcedure("Melsoft_3E_Revc");
                HDevProcedureCall getDataPlcCall = new HDevProcedureCall(getDataPlc);
                HDevProcedure GetBitPlc = new HDevProcedure("Get_Bit_Of_Word");
                HDevProcedureCall GetBitPlcCall = new HDevProcedureCall(GetBitPlc);
                //_getDataPLC.SetInputCtrlParamTuple(["String","Destination","Lenght","Socket"],
                getDataPlcCall.SetInputCtrlParamTuple("Data_Type", "Word");
                getDataPlcCall.SetInputCtrlParamTuple("Destination", Dxxx);
                getDataPlcCall.SetInputCtrlParamTuple("Lenght", 1);
                getDataPlcCall.SetInputCtrlParamTuple("Socket", socket);
                getDataPlcCall.Execute();
                data = getDataPlcCall.GetOutputCtrlParamTuple("Data_Tuple");
                GetBitPlcCall.SetInputCtrlParamTuple("Data", data);
                GetBitPlcCall.SetInputCtrlParamTuple("Order_Tuple", GetIndexBit);
                GetBitPlcCall.Execute();
                data = GetBitPlcCall.GetOutputCtrlParamTuple("Out_Tuple");
            }
            catch (Exception ex)
            {
                data = "Error";
            }
            return data;
        }
        public static HTuple SetBitFromPLC(HTuple Dxxx, HTuple SetIndexBit, HTuple ValueBit, HTuple socket)
        {
            HTuple data = -1;
            try
            {
                HDevProcedure getDataPlc = new HDevProcedure("Melsoft_3E_Revc");
                HDevProcedureCall getDataPlcCall = new HDevProcedureCall(getDataPlc);
                HDevProcedure setBitPlc = new HDevProcedure("Set_Bit_To_Word");
                HDevProcedureCall setBitPlcCall = new HDevProcedureCall(setBitPlc);
                HDevProcedure setDataPlc = new HDevProcedure("Melsoft_3E_Send");
                HDevProcedureCall setDataPlcCall = new HDevProcedureCall(setDataPlc);
                //_getDataPLC.SetInputCtrlParamTuple(["String","Destination","Lenght","Socket"],)
                getDataPlcCall.SetInputCtrlParamTuple("Data_Type", "Word");
                getDataPlcCall.SetInputCtrlParamTuple("Destination", Dxxx);
                getDataPlcCall.SetInputCtrlParamTuple("Lenght", 1);
                getDataPlcCall.SetInputCtrlParamTuple("Socket", socket);

                getDataPlcCall.Execute();
                data = getDataPlcCall.GetOutputCtrlParamTuple("Data_Tuple");
                setBitPlcCall.SetInputCtrlParamTuple("Data", data);
                setBitPlcCall.SetInputCtrlParamTuple("Order_Tuple", SetIndexBit);
                setBitPlcCall.SetInputCtrlParamTuple("Order_Value", ValueBit);
                setBitPlcCall.Execute();
                data = setBitPlcCall.GetOutputCtrlParamTuple("D_Out");


                setDataPlcCall.SetInputCtrlParamTuple("Data_Type", "Word");
                setDataPlcCall.SetInputCtrlParamTuple("Data_Tuple", data);
                setDataPlcCall.SetInputCtrlParamTuple("Destination", Dxxx);
                setDataPlcCall.SetInputCtrlParamTuple("Socket", socket);
                setDataPlcCall.Execute();
                data = setDataPlcCall.GetOutputCtrlParamTuple("CCode");

            }
            catch (Exception ex)
            {

                data = "Error";
            }
            return data;
        }
    }

}
