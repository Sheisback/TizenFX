//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 3.0.9
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------

namespace Tizen.NUI
{

    /// <summary>
    /// A LongPressGesture is emitted when the user holds the screen with the stated number of fingers.<br>
    /// Long press gesture finishes when all touches have been released.<br>
    /// </summary>
    public class LongPressGesture : Gesture
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal LongPressGesture(global::System.IntPtr cPtr, bool cMemoryOwn) : base(NDalicPINVOKE.LongPressGesture_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(LongPressGesture obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        protected override void Dispose(DisposeTypes type)
        {
            if(disposed)
            {
                return;
            }

            if(type == DisposeTypes.Explicit)
            {
                //Called by User
                //Release your own managed resources here.
                //You should release all of your own disposable objects here.
            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.

            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                if (swigCMemOwn)
                {
                    swigCMemOwn = false;
                    NDalicPINVOKE.delete_LongPressGesture(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }


        internal static LongPressGesture GetLongPressGestureFromPtr(global::System.IntPtr cPtr)
        {
            LongPressGesture ret = new LongPressGesture(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// The number of touch points in this long press gesture, i.e. the number of fingers the user had
        /// on the screen to generate the long press gesture.<br>
        /// </summary>
        public uint NumberOfTouches
        {
            get
            {
                return numberOfTouches;
            }
        }

        /// <summary>
        /// This is the point, in screen coordinates, where the long press occurred.<br>
        /// If a multi-touch long press, then this is the centroid of all the touch points.<br>
        /// </summary>
        public Vector2 ScreenPoint
        {
            get
            {
                return screenPoint;
            }
        }

        /// <summary>
        /// This is the point, in local actor coordinates, where the long press occurred.<br>
        /// If a multi-touch long press, then this is the centroid of all the touch points.<br>
        /// </summary>
        public Vector2 LocalPoint
        {
            get
            {
                return localPoint;
            }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="state">The state of the gesture</param>
        public LongPressGesture(Gesture.StateType state) : this(NDalicPINVOKE.new_LongPressGesture__SWIG_0((int)state), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }


        private uint numberOfTouches
        {
            set
            {
                NDalicPINVOKE.LongPressGesture_numberOfTouches_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                uint ret = NDalicPINVOKE.LongPressGesture_numberOfTouches_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private Vector2 screenPoint
        {
            set
            {
                NDalicPINVOKE.LongPressGesture_screenPoint_set(swigCPtr, Vector2.getCPtr(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.LongPressGesture_screenPoint_get(swigCPtr);
                Vector2 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector2(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private Vector2 localPoint
        {
            set
            {
                NDalicPINVOKE.LongPressGesture_localPoint_set(swigCPtr, Vector2.getCPtr(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.LongPressGesture_localPoint_get(swigCPtr);
                Vector2 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector2(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

    }

}
