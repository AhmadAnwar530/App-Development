; ModuleID = 'obj\Debug\130\android\marshal_methods.x86.ll'
source_filename = "obj\Debug\130\android\marshal_methods.x86.ll"
target datalayout = "e-m:e-p:32:32-p270:32:32-p271:32:32-p272:64:64-f64:32:64-f80:32-n8:16:32-S128"
target triple = "i686-unknown-linux-android"


%struct.MonoImage = type opaque

%struct.MonoClass = type opaque

%struct.MarshalMethodsManagedClass = type {
	i32,; uint32_t token
	%struct.MonoClass*; MonoClass* klass
}

%struct.MarshalMethodName = type {
	i64,; uint64_t id
	i8*; char* name
}

%class._JNIEnv = type opaque

%class._jobject = type {
	i8; uint8_t b
}

%class._jclass = type {
	i8; uint8_t b
}

%class._jstring = type {
	i8; uint8_t b
}

%class._jthrowable = type {
	i8; uint8_t b
}

%class._jarray = type {
	i8; uint8_t b
}

%class._jobjectArray = type {
	i8; uint8_t b
}

%class._jbooleanArray = type {
	i8; uint8_t b
}

%class._jbyteArray = type {
	i8; uint8_t b
}

%class._jcharArray = type {
	i8; uint8_t b
}

%class._jshortArray = type {
	i8; uint8_t b
}

%class._jintArray = type {
	i8; uint8_t b
}

%class._jlongArray = type {
	i8; uint8_t b
}

%class._jfloatArray = type {
	i8; uint8_t b
}

%class._jdoubleArray = type {
	i8; uint8_t b
}

; assembly_image_cache
@assembly_image_cache = local_unnamed_addr global [0 x %struct.MonoImage*] zeroinitializer, align 4
; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = local_unnamed_addr constant [234 x i32] [
	i32 32687329, ; 0: Xamarin.AndroidX.Lifecycle.Runtime => 0x1f2c4e1 => 62
	i32 34715100, ; 1: Xamarin.Google.Guava.ListenableFuture.dll => 0x211b5dc => 93
	i32 57263871, ; 2: Xamarin.Forms.Core.dll => 0x369c6ff => 88
	i32 101534019, ; 3: Xamarin.AndroidX.SlidingPaneLayout => 0x60d4943 => 77
	i32 120558881, ; 4: Xamarin.AndroidX.SlidingPaneLayout.dll => 0x72f9521 => 77
	i32 165246403, ; 5: Xamarin.AndroidX.Collection.dll => 0x9d975c3 => 39
	i32 182336117, ; 6: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 79
	i32 209399409, ; 7: Xamarin.AndroidX.Browser.dll => 0xc7b2e71 => 37
	i32 220171995, ; 8: System.Diagnostics.Debug => 0xd1f8edb => 109
	i32 230216969, ; 9: Xamarin.AndroidX.Legacy.Support.Core.Utils.dll => 0xdb8d509 => 56
	i32 231814094, ; 10: System.Globalization => 0xdd133ce => 113
	i32 232815796, ; 11: System.Web.Services => 0xde07cb4 => 106
	i32 261689757, ; 12: Xamarin.AndroidX.ConstraintLayout.dll => 0xf99119d => 42
	i32 278686392, ; 13: Xamarin.AndroidX.Lifecycle.LiveData.dll => 0x109c6ab8 => 60
	i32 280482487, ; 14: Xamarin.AndroidX.Interpolator => 0x10b7d2b7 => 54
	i32 318968648, ; 15: Xamarin.AndroidX.Activity.dll => 0x13031348 => 28
	i32 321597661, ; 16: System.Numerics => 0x132b30dd => 22
	i32 342366114, ; 17: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 58
	i32 347068432, ; 18: SQLitePCLRaw.lib.e_sqlite3.android.dll => 0x14afd810 => 16
	i32 385762202, ; 19: System.Memory.dll => 0x16fe439a => 21
	i32 441335492, ; 20: Xamarin.AndroidX.ConstraintLayout.Core => 0x1a4e3ec4 => 41
	i32 442521989, ; 21: Xamarin.Essentials => 0x1a605985 => 87
	i32 442565967, ; 22: System.Collections => 0x1a61054f => 107
	i32 450948140, ; 23: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 53
	i32 465846621, ; 24: mscorlib => 0x1bc4415d => 8
	i32 469710990, ; 25: System.dll => 0x1bff388e => 20
	i32 476646585, ; 26: Xamarin.AndroidX.Interpolator.dll => 0x1c690cb9 => 54
	i32 486930444, ; 27: Xamarin.AndroidX.LocalBroadcastManager.dll => 0x1d05f80c => 66
	i32 526420162, ; 28: System.Transactions.dll => 0x1f6088c2 => 101
	i32 545304856, ; 29: System.Runtime.Extensions => 0x2080b118 => 110
	i32 605376203, ; 30: System.IO.Compression.FileSystem => 0x24154ecb => 104
	i32 627609679, ; 31: Xamarin.AndroidX.CustomView => 0x2568904f => 47
	i32 639843206, ; 32: Xamarin.AndroidX.Emoji2.ViewsHelper.dll => 0x26233b86 => 52
	i32 663517072, ; 33: Xamarin.AndroidX.VersionedParcelable => 0x278c7790 => 84
	i32 666292255, ; 34: Xamarin.AndroidX.Arch.Core.Common.dll => 0x27b6d01f => 33
	i32 690569205, ; 35: System.Xml.Linq.dll => 0x29293ff5 => 27
	i32 700284507, ; 36: Xamarin.Jetbrains.Annotations => 0x29bd7e5b => 94
	i32 747282651, ; 37: ScreenTemplate.Android.dll => 0x2c8aa0db => 0
	i32 748832960, ; 38: SQLitePCLRaw.batteries_v2 => 0x2ca248c0 => 14
	i32 775507847, ; 39: System.IO.Compression => 0x2e394f87 => 103
	i32 809851609, ; 40: System.Drawing.Common.dll => 0x30455ad9 => 98
	i32 843511501, ; 41: Xamarin.AndroidX.Print => 0x3246f6cd => 73
	i32 877678880, ; 42: System.Globalization.dll => 0x34505120 => 113
	i32 912572698, ; 43: Xamarin.AndroidX.Biometric => 0x3664c11a => 36
	i32 928116545, ; 44: Xamarin.Google.Guava.ListenableFuture => 0x3751ef41 => 93
	i32 967690846, ; 45: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 58
	i32 974778368, ; 46: FormsViewGroup.dll => 0x3a19f000 => 4
	i32 992768348, ; 47: System.Collections.dll => 0x3b2c715c => 107
	i32 1012816738, ; 48: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 76
	i32 1035644815, ; 49: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 32
	i32 1042160112, ; 50: Xamarin.Forms.Platform.dll => 0x3e1e19f0 => 90
	i32 1044663988, ; 51: System.Linq.Expressions.dll => 0x3e444eb4 => 111
	i32 1052210849, ; 52: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 63
	i32 1084122840, ; 53: Xamarin.Kotlin.StdLib => 0x409e66d8 => 96
	i32 1098259244, ; 54: System => 0x41761b2c => 20
	i32 1175144683, ; 55: Xamarin.AndroidX.VectorDrawable.Animated => 0x460b48eb => 82
	i32 1178241025, ; 56: Xamarin.AndroidX.Navigation.Runtime.dll => 0x463a8801 => 70
	i32 1204270330, ; 57: Xamarin.AndroidX.Arch.Core.Common => 0x47c7b4fa => 33
	i32 1264511973, ; 58: Xamarin.AndroidX.Startup.StartupRuntime.dll => 0x4b5eebe5 => 78
	i32 1267360935, ; 59: Xamarin.AndroidX.VectorDrawable => 0x4b8a64a7 => 83
	i32 1292207520, ; 60: SQLitePCLRaw.core.dll => 0x4d0585a0 => 15
	i32 1293217323, ; 61: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 49
	i32 1324164729, ; 62: System.Linq => 0x4eed2679 => 112
	i32 1365406463, ; 63: System.ServiceModel.Internals.dll => 0x516272ff => 97
	i32 1376866003, ; 64: Xamarin.AndroidX.SavedState => 0x52114ed3 => 76
	i32 1395857551, ; 65: Xamarin.AndroidX.Media.dll => 0x5333188f => 67
	i32 1406073936, ; 66: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 43
	i32 1411638395, ; 67: System.Runtime.CompilerServices.Unsafe => 0x5423e47b => 24
	i32 1448217789, ; 68: ScreenTemplate => 0x56520cbd => 10
	i32 1457743152, ; 69: System.Runtime.Extensions.dll => 0x56e36530 => 110
	i32 1460219004, ; 70: Xamarin.Forms.Xaml => 0x57092c7c => 91
	i32 1462112819, ; 71: System.IO.Compression.dll => 0x57261233 => 103
	i32 1469204771, ; 72: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 31
	i32 1550322496, ; 73: System.Reflection.Extensions.dll => 0x5c680b40 => 1
	i32 1582372066, ; 74: Xamarin.AndroidX.DocumentFile.dll => 0x5e5114e2 => 48
	i32 1592978981, ; 75: System.Runtime.Serialization.dll => 0x5ef2ee25 => 3
	i32 1600778655, ; 76: SQLite.Net.Platform.XamarinAndroid.dll => 0x5f69f19f => 13
	i32 1622152042, ; 77: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 65
	i32 1624863272, ; 78: Xamarin.AndroidX.ViewPager2 => 0x60d97228 => 86
	i32 1635184631, ; 79: Xamarin.AndroidX.Emoji2.ViewsHelper => 0x6176eff7 => 52
	i32 1636350590, ; 80: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 46
	i32 1637997082, ; 81: SQLite.Net.Platform.XamarinAndroid => 0x61a1da1a => 13
	i32 1639515021, ; 82: System.Net.Http.dll => 0x61b9038d => 2
	i32 1657153582, ; 83: System.Runtime => 0x62c6282e => 25
	i32 1658241508, ; 84: Xamarin.AndroidX.Tracing.Tracing.dll => 0x62d6c1e4 => 80
	i32 1658251792, ; 85: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 92
	i32 1670060433, ; 86: Xamarin.AndroidX.ConstraintLayout => 0x638b1991 => 42
	i32 1698840827, ; 87: Xamarin.Kotlin.StdLib.Common => 0x654240fb => 95
	i32 1701541528, ; 88: System.Diagnostics.Debug.dll => 0x656b7698 => 109
	i32 1711441057, ; 89: SQLitePCLRaw.lib.e_sqlite3.android => 0x660284a1 => 16
	i32 1726116996, ; 90: System.Reflection.dll => 0x66e27484 => 108
	i32 1729485958, ; 91: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 38
	i32 1765942094, ; 92: System.Reflection.Extensions => 0x6942234e => 1
	i32 1766324549, ; 93: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 79
	i32 1776026572, ; 94: System.Core.dll => 0x69dc03cc => 19
	i32 1788241197, ; 95: Xamarin.AndroidX.Fragment => 0x6a96652d => 53
	i32 1808609942, ; 96: Xamarin.AndroidX.Loader => 0x6bcd3296 => 65
	i32 1813058853, ; 97: Xamarin.Kotlin.StdLib.dll => 0x6c111525 => 96
	i32 1813201214, ; 98: Xamarin.Google.Android.Material => 0x6c13413e => 92
	i32 1818569960, ; 99: Xamarin.AndroidX.Navigation.UI.dll => 0x6c652ce8 => 71
	i32 1858542181, ; 100: System.Linq.Expressions => 0x6ec71a65 => 111
	i32 1867746548, ; 101: Xamarin.Essentials.dll => 0x6f538cf4 => 87
	i32 1878053835, ; 102: Xamarin.Forms.Xaml.dll => 0x6ff0d3cb => 91
	i32 1885316902, ; 103: Xamarin.AndroidX.Arch.Core.Runtime.dll => 0x705fa726 => 34
	i32 1919157823, ; 104: Xamarin.AndroidX.MultiDex.dll => 0x7264063f => 68
	i32 1983156543, ; 105: Xamarin.Kotlin.StdLib.Common.dll => 0x7634913f => 95
	i32 2011961780, ; 106: System.Buffers.dll => 0x77ec19b4 => 18
	i32 2019465201, ; 107: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 63
	i32 2055257422, ; 108: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 59
	i32 2079903147, ; 109: System.Runtime.dll => 0x7bf8cdab => 25
	i32 2090596640, ; 110: System.Numerics.Vectors => 0x7c9bf920 => 23
	i32 2097448633, ; 111: Xamarin.AndroidX.Legacy.Support.Core.UI => 0x7d0486b9 => 55
	i32 2103459038, ; 112: SQLitePCLRaw.provider.e_sqlite3.dll => 0x7d603cde => 17
	i32 2126786730, ; 113: Xamarin.Forms.Platform.Android => 0x7ec430aa => 89
	i32 2201231467, ; 114: System.Net.Http => 0x8334206b => 2
	i32 2217644978, ; 115: Xamarin.AndroidX.VectorDrawable.Animated.dll => 0x842e93b2 => 82
	i32 2244775296, ; 116: Xamarin.AndroidX.LocalBroadcastManager => 0x85cc8d80 => 66
	i32 2256548716, ; 117: Xamarin.AndroidX.MultiDex => 0x8680336c => 68
	i32 2261435625, ; 118: Xamarin.AndroidX.Legacy.Support.V4.dll => 0x86cac4e9 => 57
	i32 2279755925, ; 119: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 74
	i32 2315684594, ; 120: Xamarin.AndroidX.Annotation.dll => 0x8a068af2 => 29
	i32 2403452196, ; 121: Xamarin.AndroidX.Emoji2.dll => 0x8f41c524 => 51
	i32 2409053734, ; 122: Xamarin.AndroidX.Preference.dll => 0x8f973e26 => 72
	i32 2428790861, ; 123: Plugin.Fingerprint => 0x90c4684d => 9
	i32 2454642406, ; 124: System.Text.Encoding.dll => 0x924edee6 => 115
	i32 2465273461, ; 125: SQLitePCLRaw.batteries_v2.dll => 0x92f11675 => 14
	i32 2465532216, ; 126: Xamarin.AndroidX.ConstraintLayout.Core.dll => 0x92f50938 => 41
	i32 2471215200, ; 127: ImageCircle.Forms.Plugin => 0x934bc060 => 5
	i32 2471841756, ; 128: netstandard.dll => 0x93554fdc => 99
	i32 2475788418, ; 129: Java.Interop.dll => 0x93918882 => 6
	i32 2483946094, ; 130: Plugin.Fingerprint.dll => 0x940e026e => 9
	i32 2501346920, ; 131: System.Data.DataSetExtensions => 0x95178668 => 102
	i32 2505896520, ; 132: Xamarin.AndroidX.Lifecycle.Runtime.dll => 0x955cf248 => 62
	i32 2526443681, ; 133: Xamarin.AndroidX.Biometric.dll => 0x969678a1 => 36
	i32 2581819634, ; 134: Xamarin.AndroidX.VectorDrawable.dll => 0x99e370f2 => 83
	i32 2620871830, ; 135: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 46
	i32 2624644809, ; 136: Xamarin.AndroidX.DynamicAnimation => 0x9c70e6c9 => 50
	i32 2633051222, ; 137: Xamarin.AndroidX.Lifecycle.LiveData => 0x9cf12c56 => 60
	i32 2661030023, ; 138: ScreenTemplate.dll => 0x9e9c1887 => 10
	i32 2701096212, ; 139: Xamarin.AndroidX.Tracing.Tracing => 0xa0ff7514 => 80
	i32 2732626843, ; 140: Xamarin.AndroidX.Activity => 0xa2e0939b => 28
	i32 2737747696, ; 141: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 31
	i32 2766581644, ; 142: Xamarin.Forms.Core => 0xa4e6af8c => 88
	i32 2770495804, ; 143: Xamarin.Jetbrains.Annotations.dll => 0xa522693c => 94
	i32 2778768386, ; 144: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 85
	i32 2779977773, ; 145: Xamarin.AndroidX.ResourceInspection.Annotation.dll => 0xa5b3182d => 75
	i32 2810250172, ; 146: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 43
	i32 2819470561, ; 147: System.Xml.dll => 0xa80db4e1 => 26
	i32 2821294376, ; 148: Xamarin.AndroidX.ResourceInspection.Annotation => 0xa8298928 => 75
	i32 2853208004, ; 149: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 85
	i32 2855708567, ; 150: Xamarin.AndroidX.Transition => 0xaa36a797 => 81
	i32 2901442782, ; 151: System.Reflection => 0xacf080de => 108
	i32 2903344695, ; 152: System.ComponentModel.Composition => 0xad0d8637 => 105
	i32 2905242038, ; 153: mscorlib.dll => 0xad2a79b6 => 8
	i32 2916838712, ; 154: Xamarin.AndroidX.ViewPager2.dll => 0xaddb6d38 => 86
	i32 2919462931, ; 155: System.Numerics.Vectors.dll => 0xae037813 => 23
	i32 2921128767, ; 156: Xamarin.AndroidX.Annotation.Experimental.dll => 0xae1ce33f => 30
	i32 2978675010, ; 157: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 49
	i32 2996846495, ; 158: Xamarin.AndroidX.Lifecycle.Process.dll => 0xb2a03f9f => 61
	i32 3016983068, ; 159: Xamarin.AndroidX.Startup.StartupRuntime => 0xb3d3821c => 78
	i32 3024354802, ; 160: Xamarin.AndroidX.Legacy.Support.Core.Utils => 0xb443fdf2 => 56
	i32 3044182254, ; 161: FormsViewGroup => 0xb57288ee => 4
	i32 3057625584, ; 162: Xamarin.AndroidX.Navigation.Common => 0xb63fa9f0 => 69
	i32 3111772706, ; 163: System.Runtime.Serialization => 0xb979e222 => 3
	i32 3204380047, ; 164: System.Data.dll => 0xbefef58f => 100
	i32 3211777861, ; 165: Xamarin.AndroidX.DocumentFile => 0xbf6fd745 => 48
	i32 3220365878, ; 166: System.Threading => 0xbff2e236 => 114
	i32 3247949154, ; 167: Mono.Security => 0xc197c562 => 116
	i32 3258312781, ; 168: Xamarin.AndroidX.CardView => 0xc235e84d => 38
	i32 3267021929, ; 169: Xamarin.AndroidX.AsyncLayoutInflater => 0xc2bacc69 => 35
	i32 3286872994, ; 170: SQLite-net.dll => 0xc3e9b3a2 => 11
	i32 3299363146, ; 171: System.Text.Encoding => 0xc4a8494a => 115
	i32 3317135071, ; 172: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 47
	i32 3317144872, ; 173: System.Data => 0xc5b79d28 => 100
	i32 3340431453, ; 174: Xamarin.AndroidX.Arch.Core.Runtime => 0xc71af05d => 34
	i32 3346324047, ; 175: Xamarin.AndroidX.Navigation.Runtime => 0xc774da4f => 70
	i32 3353484488, ; 176: Xamarin.AndroidX.Legacy.Support.Core.UI.dll => 0xc7e21cc8 => 55
	i32 3360279109, ; 177: SQLitePCLRaw.core => 0xc849ca45 => 15
	i32 3362522851, ; 178: Xamarin.AndroidX.Core => 0xc86c06e3 => 45
	i32 3366347497, ; 179: Java.Interop => 0xc8a662e9 => 6
	i32 3374999561, ; 180: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 74
	i32 3395150330, ; 181: System.Runtime.CompilerServices.Unsafe.dll => 0xca5de1fa => 24
	i32 3404865022, ; 182: System.ServiceModel.Internals => 0xcaf21dfe => 97
	i32 3429136800, ; 183: System.Xml => 0xcc6479a0 => 26
	i32 3430777524, ; 184: netstandard => 0xcc7d82b4 => 99
	i32 3441283291, ; 185: Xamarin.AndroidX.DynamicAnimation.dll => 0xcd1dd0db => 50
	i32 3476120550, ; 186: Mono.Android => 0xcf3163e6 => 7
	i32 3483112796, ; 187: ImageCircle.Forms.Plugin.dll => 0xcf9c155c => 5
	i32 3486566296, ; 188: System.Transactions => 0xcfd0c798 => 101
	i32 3493954962, ; 189: Xamarin.AndroidX.Concurrent.Futures.dll => 0xd0418592 => 40
	i32 3501239056, ; 190: Xamarin.AndroidX.AsyncLayoutInflater.dll => 0xd0b0ab10 => 35
	i32 3509114376, ; 191: System.Xml.Linq => 0xd128d608 => 27
	i32 3536029504, ; 192: Xamarin.Forms.Platform.Android.dll => 0xd2c38740 => 89
	i32 3544605649, ; 193: SQLite.Net.dll => 0xd34663d1 => 12
	i32 3567349600, ; 194: System.ComponentModel.Composition.dll => 0xd4a16f60 => 105
	i32 3608519521, ; 195: System.Linq.dll => 0xd715a361 => 112
	i32 3618140916, ; 196: Xamarin.AndroidX.Preference => 0xd7a872f4 => 72
	i32 3627220390, ; 197: Xamarin.AndroidX.Print.dll => 0xd832fda6 => 73
	i32 3632359727, ; 198: Xamarin.Forms.Platform => 0xd881692f => 90
	i32 3633644679, ; 199: Xamarin.AndroidX.Annotation.Experimental => 0xd8950487 => 30
	i32 3641597786, ; 200: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 59
	i32 3672681054, ; 201: Mono.Android.dll => 0xdae8aa5e => 7
	i32 3676310014, ; 202: System.Web.Services.dll => 0xdb2009fe => 106
	i32 3682565725, ; 203: Xamarin.AndroidX.Browser => 0xdb7f7e5d => 37
	i32 3684561358, ; 204: Xamarin.AndroidX.Concurrent.Futures => 0xdb9df1ce => 40
	i32 3689375977, ; 205: System.Drawing.Common => 0xdbe768e9 => 98
	i32 3697130073, ; 206: SQLite.Net => 0xdc5dba59 => 12
	i32 3706696989, ; 207: Xamarin.AndroidX.Core.Core.Ktx.dll => 0xdcefb51d => 44
	i32 3718780102, ; 208: Xamarin.AndroidX.Annotation => 0xdda814c6 => 29
	i32 3724971120, ; 209: Xamarin.AndroidX.Navigation.Common.dll => 0xde068c70 => 69
	i32 3754567612, ; 210: SQLitePCLRaw.provider.e_sqlite3 => 0xdfca27bc => 17
	i32 3758932259, ; 211: Xamarin.AndroidX.Legacy.Support.V4 => 0xe00cc123 => 57
	i32 3786282454, ; 212: Xamarin.AndroidX.Collection => 0xe1ae15d6 => 39
	i32 3822602673, ; 213: Xamarin.AndroidX.Media => 0xe3d849b1 => 67
	i32 3829621856, ; 214: System.Numerics.dll => 0xe4436460 => 22
	i32 3876362041, ; 215: SQLite-net => 0xe70c9739 => 11
	i32 3885922214, ; 216: Xamarin.AndroidX.Transition.dll => 0xe79e77a6 => 81
	i32 3896760992, ; 217: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 45
	i32 3920810846, ; 218: System.IO.Compression.FileSystem.dll => 0xe9b2d35e => 104
	i32 3921031405, ; 219: Xamarin.AndroidX.VersionedParcelable.dll => 0xe9b630ed => 84
	i32 3931092270, ; 220: Xamarin.AndroidX.Navigation.UI => 0xea4fb52e => 71
	i32 3945713374, ; 221: System.Data.DataSetExtensions.dll => 0xeb2ecede => 102
	i32 3955647286, ; 222: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 32
	i32 3959773229, ; 223: Xamarin.AndroidX.Lifecycle.Process => 0xec05582d => 61
	i32 4025784931, ; 224: System.Memory => 0xeff49a63 => 21
	i32 4073602200, ; 225: System.Threading.dll => 0xf2ce3c98 => 114
	i32 4101593132, ; 226: Xamarin.AndroidX.Emoji2 => 0xf479582c => 51
	i32 4105002889, ; 227: Mono.Security.dll => 0xf4ad5f89 => 116
	i32 4151237749, ; 228: System.Core => 0xf76edc75 => 19
	i32 4182413190, ; 229: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0xf94a8f86 => 64
	i32 4256097574, ; 230: Xamarin.AndroidX.Core.Core.Ktx => 0xfdaee526 => 44
	i32 4260525087, ; 231: System.Buffers => 0xfdf2741f => 18
	i32 4285548997, ; 232: ScreenTemplate.Android => 0xff7049c5 => 0
	i32 4292120959 ; 233: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xffd4917f => 64
], align 4
@assembly_image_cache_indices = local_unnamed_addr constant [234 x i32] [
	i32 62, i32 93, i32 88, i32 77, i32 77, i32 39, i32 79, i32 37, ; 0..7
	i32 109, i32 56, i32 113, i32 106, i32 42, i32 60, i32 54, i32 28, ; 8..15
	i32 22, i32 58, i32 16, i32 21, i32 41, i32 87, i32 107, i32 53, ; 16..23
	i32 8, i32 20, i32 54, i32 66, i32 101, i32 110, i32 104, i32 47, ; 24..31
	i32 52, i32 84, i32 33, i32 27, i32 94, i32 0, i32 14, i32 103, ; 32..39
	i32 98, i32 73, i32 113, i32 36, i32 93, i32 58, i32 4, i32 107, ; 40..47
	i32 76, i32 32, i32 90, i32 111, i32 63, i32 96, i32 20, i32 82, ; 48..55
	i32 70, i32 33, i32 78, i32 83, i32 15, i32 49, i32 112, i32 97, ; 56..63
	i32 76, i32 67, i32 43, i32 24, i32 10, i32 110, i32 91, i32 103, ; 64..71
	i32 31, i32 1, i32 48, i32 3, i32 13, i32 65, i32 86, i32 52, ; 72..79
	i32 46, i32 13, i32 2, i32 25, i32 80, i32 92, i32 42, i32 95, ; 80..87
	i32 109, i32 16, i32 108, i32 38, i32 1, i32 79, i32 19, i32 53, ; 88..95
	i32 65, i32 96, i32 92, i32 71, i32 111, i32 87, i32 91, i32 34, ; 96..103
	i32 68, i32 95, i32 18, i32 63, i32 59, i32 25, i32 23, i32 55, ; 104..111
	i32 17, i32 89, i32 2, i32 82, i32 66, i32 68, i32 57, i32 74, ; 112..119
	i32 29, i32 51, i32 72, i32 9, i32 115, i32 14, i32 41, i32 5, ; 120..127
	i32 99, i32 6, i32 9, i32 102, i32 62, i32 36, i32 83, i32 46, ; 128..135
	i32 50, i32 60, i32 10, i32 80, i32 28, i32 31, i32 88, i32 94, ; 136..143
	i32 85, i32 75, i32 43, i32 26, i32 75, i32 85, i32 81, i32 108, ; 144..151
	i32 105, i32 8, i32 86, i32 23, i32 30, i32 49, i32 61, i32 78, ; 152..159
	i32 56, i32 4, i32 69, i32 3, i32 100, i32 48, i32 114, i32 116, ; 160..167
	i32 38, i32 35, i32 11, i32 115, i32 47, i32 100, i32 34, i32 70, ; 168..175
	i32 55, i32 15, i32 45, i32 6, i32 74, i32 24, i32 97, i32 26, ; 176..183
	i32 99, i32 50, i32 7, i32 5, i32 101, i32 40, i32 35, i32 27, ; 184..191
	i32 89, i32 12, i32 105, i32 112, i32 72, i32 73, i32 90, i32 30, ; 192..199
	i32 59, i32 7, i32 106, i32 37, i32 40, i32 98, i32 12, i32 44, ; 200..207
	i32 29, i32 69, i32 17, i32 57, i32 39, i32 67, i32 22, i32 11, ; 208..215
	i32 81, i32 45, i32 104, i32 84, i32 71, i32 102, i32 32, i32 61, ; 216..223
	i32 21, i32 114, i32 51, i32 116, i32 19, i32 64, i32 44, i32 18, ; 224..231
	i32 0, i32 64 ; 232..233
], align 4

@marshal_methods_number_of_classes = local_unnamed_addr constant i32 0, align 4

; marshal_methods_class_cache
@marshal_methods_class_cache = global [0 x %struct.MarshalMethodsManagedClass] [
], align 4; end of 'marshal_methods_class_cache' array


@get_function_pointer = internal unnamed_addr global void (i32, i32, i32, i8**)* null, align 4

; Function attributes: "frame-pointer"="none" "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" "stackrealign" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" uwtable willreturn writeonly
define void @xamarin_app_init (void (i32, i32, i32, i8**)* %fn) local_unnamed_addr #0
{
	store void (i32, i32, i32, i8**)* %fn, void (i32, i32, i32, i8**)** @get_function_pointer, align 4
	ret void
}

; Names of classes in which marshal methods reside
@mm_class_names = local_unnamed_addr constant [0 x i8*] zeroinitializer, align 4
@__MarshalMethodName_name.0 = internal constant [1 x i8] c"\00", align 1

; mm_method_names
@mm_method_names = local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	; 0
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		i8* getelementptr inbounds ([1 x i8], [1 x i8]* @__MarshalMethodName_name.0, i32 0, i32 0); name
	}
], align 8; end of 'mm_method_names' array


attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable willreturn writeonly "frame-pointer"="none" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" "stackrealign" }
attributes #1 = { "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable "frame-pointer"="none" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" "stackrealign" }
attributes #2 = { nounwind }

!llvm.module.flags = !{!0, !1, !2}
!llvm.ident = !{!3}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!2 = !{i32 1, !"NumRegisterParameters", i32 0}
!3 = !{!"Xamarin.Android remotes/origin/d17-5 @ a200af12c1e846626b8caebd926ac14c185f71ec"}
!llvm.linker.options = !{}
