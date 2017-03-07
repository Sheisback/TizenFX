﻿/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.


using System;
using System.Runtime.InteropServices;
using Tizen.Content.MediaContent;

internal static partial class Interop
{
    internal static partial class Filter
    {
        [DllImport(Libraries.MediaContent, EntryPoint = "media_filter_create")]
        internal static extern MediaContentError Create(out IntPtr filter);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_filter_destroy")]
        internal static extern MediaContentError Destroy(IntPtr filter);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_filter_set_offset")]
        internal static extern MediaContentError SetOffset(IntPtr filter, int offset, int count);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_filter_set_condition")]
        internal static extern MediaContentError SetCondition(IntPtr filter, string condition, int collate_type);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_filter_set_order")]
        internal static extern MediaContentError SetOrder(IntPtr filter, ContentOrder order_type, string order_keyword, ContentCollation collate_type);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_filter_set_storage")]
        internal static extern MediaContentError SetStorage(IntPtr filter, string storage_id);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_filter_get_offset")]
        internal static extern MediaContentError GetOffset(IntPtr filter, out int offset, out int count);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_filter_get_condition")]
        internal static extern MediaContentError GetCondition(IntPtr filter, out string condition, out int collate_type);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_filter_get_order")]
        internal static extern MediaContentError GetOrder(IntPtr filter, out int order_type, out string order_keyword, out int collate_type);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_filter_get_storage")]
        internal static extern MediaContentError GetStorage(IntPtr filter, out string storage_id);
    }
}