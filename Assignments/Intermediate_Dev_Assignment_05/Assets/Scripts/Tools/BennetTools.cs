using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;

namespace BennetTools
{
    public static class Tools
    {
        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        public static bool ValueEquals<T,U>(this U self, T obj)
        {
            //先看看有没有复写Equals
            if (!self.GetType().GetInterfaces().Any(i => i == typeof(IEquatable<T>)))
            {
                throw new InvalidOperationException($"{self.GetType().FullName} does not implement IValueEquatable<{obj.GetType().FullName}>");
            }
            if (ReferenceEquals(self, obj)) return true;
            if (self == null || obj == null) return false;
            
            return false;
        }
        public static bool ValueEquals<T, U>(this List<U> self, List<T> obj)
        {
            if (!self.GetType().GetInterfaces().Any(i => i == typeof(IEquatable<T>)))
                

                if (self.GetType().GetInterface(typeof(IEquatable<U>).FullName) == null)
                throw new InvalidOperationException($"{typeof(U).FullName} does not implement IValueEquatable<{typeof(T).FullName}>");

            if (self == null || obj == null)
                throw new ArgumentNullException("Parameters cannot be null.");

            if (ReferenceEquals(self, obj)) return true; //equal by reference

            for (int i = 0; i < self.Count; i++)
            {
                if (self[i].ValueEquals(obj[i]))
                    return false;
            }

            return false;
        }
        public static bool ValueEquals(this List<KeyCode> self, List<KeyCode> list)
        {
            if (self.Count != list.Count)
                return false;
            //iterate
            for (int i = 0; i < self.Count; i++)
            {
                if (!self[i].Equals(list[i]))
                    return false;
            }
            //everthing equals
            return true;
        }

        public static bool InputAxisActiveRaw(string name) => !Mathf.Approximately(Input.GetAxisRaw(name), 0);
        public static void AdjustColliderToFitSprite(this BoxCollider2D boxCollider2D, SpriteRenderer spriteRenderer)
        {
            if (boxCollider2D == null || spriteRenderer == null) return;

            boxCollider2D.size = spriteRenderer.sprite.bounds.size;

        }
        public static string GetCallerMethodName()
        {
            StackTrace stackTrace = new StackTrace();
            // The first frame (index 0) is the current method
            // The second frame (index 1) is the method that called the current method
            StackFrame callerFrame = stackTrace.GetFrame(1);
            // Get the method name from the stack frame
            string callerMethodName = callerFrame.GetMethod().Name;

            return callerMethodName;
        }
    }

    public interface IPauseableWhenMenuOpen
    {
        bool IsPaused { get; set; }
        /// <summary>
        /// should be called once in Start()
        /// </summary>
        void SuscribeMenuManagerEvents();
        void PauseOnMenuOpen();
        void ResumeOnMenuClose();
    }
}