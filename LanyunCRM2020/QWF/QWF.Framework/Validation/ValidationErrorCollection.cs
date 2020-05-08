using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Collections;

namespace QWF.Framework.Validation
{
    /// <summary>
    /// 校验结果集合
    /// </summary>
    public class ValidationErrorCollection : IEnumerable<ValidationError>
    {
        /// <summary>
        /// 验证结果
        /// </summary>
        private readonly List<ValidationError> _results;

        /// <summary>
        /// 初始化验证结果集合
        /// </summary>
        public ValidationErrorCollection()
        {
            _results = new List<ValidationError>();
        }

        /// <summary>
        /// 是否有效
        /// </summary>
        public bool IsValid
        {
            get
            {
                return _results.Count == 0;
            }
        }

        /// <summary>
        /// 验证结果个数
        /// </summary>
        public int Count
        {
            get
            {
                return _results.Count;
            }
        }

        /// <summary>
        /// 添加验证结果
        /// </summary>
        /// <param name="result">验证结果</param>
        public void Add(ValidationError result)
        {
            if (result == null)
                return;
            _results.Add(result);
        }

        /// <summary>
        /// 添加验证结果集合
        /// </summary>
        /// <param name="results">验证结果集合</param>
        public void AddResults(IEnumerable<ValidationError> results)
        {
            if (results == null)
                return;
            foreach (var result in results)
                Add(result);
        }

        /// <summary>
        /// 获取迭代器
        /// </summary>
        IEnumerator<ValidationError> IEnumerable<ValidationError>.GetEnumerator()
        {
            return _results.GetEnumerator();
        }

        /// <summary>
        /// 获取迭代器
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _results.GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var result in _results)
            {
                sb.AppendLine(string.Format("{0}： {1}", result.FieldName, result.Message));
            }

            return sb.ToString();
        }
    }
}
