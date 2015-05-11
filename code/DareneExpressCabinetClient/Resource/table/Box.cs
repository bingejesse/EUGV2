﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DareneExpressCabinetClient.Service;
using DareneExpressCabinetClient.Service.Factory;

namespace DareneExpressCabinetClient
{
    public class Box
    {
        public enum State {Close, Open, Fault };
        public enum Size { S,M,L,XL,XXL};

        public Box()
        {
            this.isIdle = true;//初始默认柜子是空的
            this.service =ServicesFactory.GetInstance().GetBoxControlService();
            //this.currentState = service.GetCurrentState(code);
        }

        private BoxControlService service;

        private int id;
        /// <summary>
        /// 柜子ID
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int code;
        /// <summary>
        /// 柜子编号，用来表明身份,唯一
        /// </summary>
        public int Code
        {
            get { return code; }
            set { code = value; }
        }

        private bool isIdle;
        /// <summary>
        /// 是否空闲
        /// </summary>
        public bool IsIdle
        {
            get { return isIdle; }
            set { isIdle = value; }
        }

        private State currentState;
        /// <summary>
        /// 当前状态
        /// </summary>
        public State CurrentState
        {
            get { return currentState; }
            set { currentState = value; }
        }
        private Size thisSize;
        /// <summary>
        /// 柜子型号
        /// </summary>
        public Size ThisSize
        {
            get { return thisSize; }
            set { thisSize = value; }
        }

        private Coordinate coordinateInfo;
        /// <summary>
        /// 位置信息
        /// </summary>
        public Coordinate CoordinateInfo
        {
            get { return coordinateInfo; }
            set { coordinateInfo = value; }
        }

        /// <summary>
        /// 获取箱门信息
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return coordinateInfo.X.ToString() + coordinateInfo.Y.ToString();
        }

        private string remarkInfo;
        /// <summary>
        /// 备注信息
        /// </summary>
        public string RemarkInfo
        {
            get { return remarkInfo; }
            set { remarkInfo = value; }
        }

        /// <summary>
        /// 开柜子
        /// </summary>m
        /// <returns></returns>
        public bool Open()
        {
            if (this.currentState == State.Fault)
            {
                return false;
            }

            bool result = service.Open(this.code);
            if (result)
            {
                this.currentState = State.Open;
            }
            else
            {
                this.currentState = State.Close;
            }
            return result;
        }

        /// <summary>
        /// 关柜子
        /// </summary>
        /// <returns></returns>
        public bool Close()
        {
            if (this.currentState == State.Fault)
            {
                return false;
            }

            bool result = service.Open(this.code);
            if (result)
            {
                this.currentState = State.Close;
            }
            else
            {
                this.currentState = State.Open;
            }
            return result;
        }

        /// <summary>
        /// 位置信息
        /// </summary>
        public struct Coordinate
        {
            public int X;
            public int Y;
        }

    }
}
