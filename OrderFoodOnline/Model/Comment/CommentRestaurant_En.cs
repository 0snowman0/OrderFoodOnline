﻿using OrderFoodOnline.Model.Common.Total;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace OrderFoodOnline.Model.Comment
{
    public class CommentRestaurant_En : BaseEn_En
    {
        [Required]
        // شناسه رستوران
        public int RestaurantId { get; set; }
        [Required]

        // شناسه کاربر
        public int UserId { get; set; }
        [Required]
        [MaxLength(500)]
        // متن نظر
        public string Content { get; set; } = null!;
        [Required]

        // تاریخ و زمان ایجاد نظر
        public DateTime CreatedAt { get; set; }
        [Required]

        // تاریخ و زمان به‌روزرسانی نظر
        public DateTime UpdatedAt { get; set; }
        [Required]
        // آیا نظر یک ریپلای است؟
        public bool IsReplye { get; set; }

        [DefaultValue(0)]
        // شناسه نظری که به آن ریپلای داده شده است
        public int? IdCommentReplye { get; set; }

        [Required]
        public bool IsReport { get; set; }

    }
}
