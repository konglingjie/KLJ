﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonLibrary4.Retrying
{
    /// <summary>
    /// Retry事件参数
    /// </summary>
    public class RetryingEventArgs : EventArgs
    {
        /// <summary>
        /// 当前重试的次数
        /// </summary>
        public int CurrentRetryCount { get; private set; }
        /// <summary>
        /// 最后一次触发的异常
        /// </summary>
        public Exception LastException { get; private set; }
        /// <summary>
        /// 重试延迟的时间
        /// </summary>
        public TimeSpan Delay { get; private set; }
        /// <summary>
        /// 指示继续重试，默认为true，如果设置为false，表示立即停止重试。
        /// </summary>
        public bool Retrying { get; set; }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="retryCount">重试次数</param>
        /// <param name="lastException">引发重试的异常</param>
        /// <param name="delay">重试时间间隔</param>
        public RetryingEventArgs(int retryCount, Exception lastException, TimeSpan delay)
        {
            this.CurrentRetryCount = retryCount;
            this.LastException = lastException;
            this.Delay = delay;
            Retrying = true;
        }
    }
}
