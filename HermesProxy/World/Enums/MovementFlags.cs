﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HermesProxy.World.Enums
{
    [Flags]
    public enum MovementFlagVanilla : uint
    {
        None               = 0x00000000,
        Forward            = 0x00000001,
        Backward           = 0x00000002,
        StrafeLeft         = 0x00000004,
        StrafeRight        = 0x00000008,
        TurnLeft           = 0x00000010,
        TurnRight          = 0x00000020,
        PitchUp            = 0x00000040,
        PitchDown          = 0x00000080,
        WalkMode           = 0x00000100,
        OnTransport        = 0x02000000,
        Levitating         = 0x00000400,
        FixedZ             = 0x00000800,
        Root               = 0x00001000,
        Falling            = 0x00002000,
        FallingFar         = 0x00004000,
        Swimming           = 0x00200000,
        SplineEnabled      = 0x00400000,
        CanFly             = 0x00800000,
        Flying             = 0x01000000,
        SplineElevation    = 0x04000000,
        Waterwalking       = 0x10000000,
        CanSafeFall        = 0x20000000,
        Hover              = 0x40000000,
    }

    [Flags]
    public enum MovementFlagTBC : uint
    {
        None               = 0x00000000,
        Forward            = 0x00000001,
        Backward           = 0x00000002,
        StrafeLeft         = 0x00000004,
        StrafeRight        = 0x00000008,
        TurnLeft           = 0x00000010,
        TurnRight          = 0x00000020,
        PitchUp            = 0x00000040,
        PitchDown          = 0x00000080,
        WalkMode           = 0x00000100,
        OnTransport        = 0x00000200,
        DisableGravity     = 0x00000400,
        Root               = 0x00000800,
        Falling            = 0x00001000, // MOVEMENTFLAG_JUMPING_OR_FALLING
        FallingFar         = 0x00002000,
        PendingStop        = 0x00004000,
        PendingStrafeStop  = 0x00008000,
        PendingForward     = 0x00010000,
        PendingBackward    = 0x00020000,
        PendingStrafeLeft  = 0x00040000,
        PendingStrafeRight = 0x00080000,
        PendingRoot        = 0x00100000,
        Swimming           = 0x00200000,
        Ascending          = 0x00400000,
        Descending         = 0x00800000,
        CanFly             = 0x01000000, // MOVEMENTFLAG_CAN_FLY
        Flying             = 0x02000000, // MOVEMENTFLAG_PLAYER_FLYING
        SplineElevation    = 0x04000000,
        SplineEnabled      = 0x08000000,
        Waterwalking       = 0x10000000,
        CanSafeFall        = 0x20000000, // MOVEMENTFLAG_FALLING_SLOW
        Hover              = 0x40000000,
    }

    [Flags]
    public enum MovementFlagWotLK : uint
    {
        None               = 0x00000000,
        Forward            = 0x00000001,
        Backward           = 0x00000002,
        StrafeLeft         = 0x00000004,
        StrafeRight        = 0x00000008,
        TurnLeft           = 0x00000010,
        TurnRight          = 0x00000020,
        PitchUp            = 0x00000040,
        PitchDown          = 0x00000080,
        WalkMode           = 0x00000100,
        OnTransport        = 0x00000200,
        DisableGravity     = 0x00000400,
        Root               = 0x00000800,
        Falling            = 0x00001000,
        FallingFar         = 0x00002000,
        PendingStop        = 0x00004000,
        PendingStrafeStop  = 0x00008000,
        PendingForward     = 0x00010000,
        PendingBackward    = 0x00020000,
        PendingStrafeLeft  = 0x00040000,
        PendingStrafeRight = 0x00080000,
        PendingRoot        = 0x00100000,
        Swimming           = 0x00200000,
        Ascending          = 0x00400000,
        Descending         = 0x00800000,
        CanFly             = 0x01000000,
        Flying             = 0x02000000,
        SplineElevation    = 0x04000000,
        SplineEnabled      = 0x08000000,
        Waterwalking       = 0x10000000,
        CanSafeFall        = 0x20000000,
        Hover              = 0x40000000,
        LocalDirty         = 0x80000000
    }

    [Flags]
    public enum MovementFlagModern : uint
    {
        None               = 0x00000000,
        Forward            = 0x00000001,
        Backward           = 0x00000002,
        StrafeLeft         = 0x00000004,
        StrafeRight        = 0x00000008,
        TurnLeft           = 0x00000010,
        TurnRight          = 0x00000020,
        PitchUp            = 0x00000040,
        PitchDown          = 0x00000080,
        WalkMode           = 0x00000100,
        DisableGravity     = 0x00000200,
        Root               = 0x00000400,
        Falling            = 0x00000800,
        FallingFar         = 0x00001000,
        PendingStop        = 0x00002000,
        PendingStrafeStop  = 0x00004000,
        PendingForward     = 0x00008000,
        PendingBackward    = 0x00010000,
        PendingStrafeLeft  = 0x00020000,
        PendingStrafeRight = 0x00040000,
        PendingRoot        = 0x00080000,
        Swimming           = 0x00100000,
        Ascending          = 0x00200000,
        Descending         = 0x00400000,
        CanFly             = 0x00800000,
        Flying             = 0x01000000,
        SplineElevation    = 0x02000000,
        Waterwalking       = 0x04000000,
        CanSafeFall        = 0x08000000,
        Hover              = 0x10000000,
        DisableCollision   = 0x20000000,

        MaskMoving = Forward | Backward | StrafeLeft | StrafeRight | Falling | Ascending | Descending,
    }
}
