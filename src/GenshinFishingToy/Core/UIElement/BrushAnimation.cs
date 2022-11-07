﻿using System;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace GenshinFishingToy.Core;

public class BrushAnimation : AnimationTimeline
{
    public Brush From
    {
        get { return (Brush)GetValue(FromProperty); }
        set { SetValue(FromProperty, value); }
    }

    public static readonly DependencyProperty FromProperty =
        DependencyProperty.Register("From", typeof(Brush), typeof(BrushAnimation));

    public Brush To
    {
        get { return (Brush)GetValue(ToProperty); }
        set { SetValue(ToProperty, value); }
    }

    public static readonly DependencyProperty ToProperty = DependencyProperty.Register("To", typeof(Brush), typeof(BrushAnimation));

    public override Type TargetPropertyType => typeof(Brush);

    public override object GetCurrentValue(object defaultOriginValue, object defaultDestinationValue, AnimationClock animationClock)
    {
        return GetCurrentValue((defaultOriginValue as Brush)!, (defaultDestinationValue as Brush)!, animationClock);
    }

    protected override Freezable CreateInstanceCore()
    {
        return new BrushAnimation();
    }

    public object GetCurrentValue(Brush defaultOriginValue, Brush defaultDestinationValue, AnimationClock animationClock)
    {
        if (!animationClock.CurrentProgress.HasValue)
            return Brushes.Transparent;

        defaultOriginValue = From ?? defaultOriginValue;
        defaultDestinationValue = To ?? defaultDestinationValue;

        if (animationClock.CurrentProgress.Value == 0)
            return defaultOriginValue;
        if (animationClock.CurrentProgress.Value == 1)
            return defaultDestinationValue;

        if (To != null)
        {
            if (defaultDestinationValue is SolidColorBrush && ((SolidColorBrush)defaultDestinationValue).Color.A < 255
                && (!(defaultOriginValue is SolidColorBrush) || ((SolidColorBrush)defaultOriginValue).Color.A == 255))
            {
                return GetVisualBrush(defaultDestinationValue, defaultOriginValue, 1 - animationClock.CurrentProgress.Value);
            }
            else
            {
                return GetVisualBrush(defaultOriginValue, defaultDestinationValue, animationClock.CurrentProgress.Value);
            }
        }
        else
        {
            if (defaultOriginValue is SolidColorBrush && ((SolidColorBrush)defaultOriginValue).Color.A < 255
                && (!(defaultDestinationValue is SolidColorBrush) || ((SolidColorBrush)defaultDestinationValue).Color.A == 255))
            {
                return GetVisualBrush(defaultOriginValue, defaultDestinationValue, animationClock.CurrentProgress.Value);
            }
            else
            {
                return GetVisualBrush(defaultDestinationValue, defaultOriginValue, 1 - animationClock.CurrentProgress.Value);
            }
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static VisualBrush GetVisualBrush(Brush background, Brush foreground, double opacity)
    {
        return new VisualBrush(new Border()
        {
            Width = 1,
            Height = 1,
            Background = background,

            Child = new Border()
            {
                Background = foreground,
                Opacity = opacity
            }
        });
    }
}
