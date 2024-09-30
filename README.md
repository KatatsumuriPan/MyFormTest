# MyFormTest

これはただのGoogleフォーム

https://docs.google.com/forms/d/e/1FAIpQLScx_s4O7WAONCjL2AX5rcvRzfv7Gp6OqlN7SPU0hQAJOQ_Mkw/viewform?usp=sf_link

                             **************************************************************
                             *                          FUNCTION                          *
                             **************************************************************
                             void __cdecl UpdateLiquid(SimData * simData, SimEvents *
                               assume GS_OFFSET = 0xff00000000
             void              <VOID>         <RETURN>
             SimData *         RCX:8          simData                                 XREF[2]:     180045623(W), 
                                                                                                   1800456bc(W)  
             SimEvents *       RDX:8          simEvent
             int               R8D:4          cellIndex
             longlong          R13:8          cellIndexLL                             XREF[1]:     180045549(W)  
             undefined8        R10:8          massSize                                XREF[2]:     1800455cc(W), 
                                                                                                   18004638f(W)  
             undefined4        R14D:4         downCellIdx                             XREF[2]:     180045604(W), 
                                                                                                   18004638c(W)  
             undefined8        RBP:8          downCellIndexUL                         XREF[5]:     180045607(W), 
                                                                                                   18004575d(W), 
                                                                                                   180045c22(W), 
                                                                                                   180045f49(W), 
                                                                                                   180046295(W)  
             undefined4        ECX:4          downCellElementIdx                      XREF[2]:     180045623(W), 
                                                                                                   1800456bc(W)  
             undefined8        R9:8           elementIdxSize                          XREF[2]:     180045635(W), 
                                                                                                   180046126(W)  
             byte              CL:1           downState                               XREF[1]:     1800456bc(W)  
             float             XMM0_Da:4      massDifference                          XREF[3]:     1800456fd(W), 
                                                                                                   180045bda(W), 
                                                                                                   180045f01(W)  
             undefined4        EBP:4          diseaseCountToMove                      XREF[4]:     18004575d(W), 
                                                                                                   180045c22(W), 
                                                                                                   180045f49(W), 
                                                                                                   180046295(W)  
             bool              AL:1           success                                 XREF[11]:    180045797(W), 
                                                                                                   1800458c8(W), 
                                                                                                   180045990(W), 
                                                                                                   1800459a4(W), 
                                                                                                   1800459b4(W), 
                                                                                                   1800459c8(W), 
                                                                                                   180045c26(W), 
                                                                                                   180045cda(W), 
                                                                                                   180045d36(W), 
                                                                                                   180045f4d(W), 
                                                                                                   1800462d0(W)  
             undefined4        XMM6_Da:4      cellMass                                XREF[1]:     180045808(W)  
             int               R12D:4         leftIndex2                              XREF[1]:     18004585f(W)  
             ulonglong         R15:8          leftElementULL                          XREF[3]:     18004587a(W), 
                                                                                                   180045e18(W), 
                                                                                                   180046123(W)  
             ulonglong         RAX:8          updatedLeftElement                      XREF[10]:    1800458c8(W), 
                                                                                                   180045990(W), 
                                                                                                   1800459a4(W), 
                                                                                                   1800459b4(W), 
                                                                                                   1800459c8(W), 
                                                                                                   180045c26(W), 
                                                                                                   180045cda(W), 
                                                                                                   180045d36(W), 
                                                                                                   180045f4d(W), 
                                                                                                   1800462d0(W)  
             bool              AL:1           leftPermeable                           XREF[9]:     180045990(W), 
                                                                                                   1800459a4(W), 
                                                                                                   1800459b4(W), 
                                                                                                   1800459c8(W), 
                                                                                                   180045c26(W), 
                                                                                                   180045cda(W), 
                                                                                                   180045d36(W), 
                                                                                                   180045f4d(W), 
                                                                                                   1800462d0(W)  
             undefined1        AL:1           downLeftPermeable                       XREF[8]:     1800459a4(W), 
                                                                                                   1800459b4(W), 
                                                                                                   1800459c8(W), 
                                                                                                   180045c26(W), 
                                                                                                   180045cda(W), 
                                                                                                   180045d36(W), 
                                                                                                   180045f4d(W), 
                                                                                                   1800462d0(W)  
             bool              AL:1           rightPermeable                          XREF[7]:     1800459b4(W), 
                                                                                                   1800459c8(W), 
                                                                                                   180045c26(W), 
                                                                                                   180045cda(W), 
                                                                                                   180045d36(W), 
                                                                                                   180045f4d(W), 
                                                                                                   1800462d0(W)  
             bool              AL:1           downRightPermeable                      XREF[6]:     1800459c8(W), 
                                                                                                   180045c26(W), 
                                                                                                   180045cda(W), 
                                                                                                   180045d36(W), 
                                                                                                   180045f4d(W), 
                                                                                                   1800462d0(W)  
             float             XMM0_Da:4      movableAmount$1                         XREF[2]:     180045bda(W), 
                                                                                                   180045f01(W)  
             int               EBP:4          diseaseCountToMove$1                    XREF[3]:     180045c22(W), 
                                                                                                   180045f49(W), 
                                                                                                   180046295(W)  
             bool              AL:1           downImpermeable                         XREF[5]:     180045c26(W), 
                                                                                                   180045cda(W), 
                                                                                                   180045d36(W), 
                                                                                                   180045f4d(W), 
                                                                                                   1800462d0(W)  
             bool              AL:1           success$1                               XREF[4]:     180045cda(W), 
                                                                                                   180045d36(W), 
                                                                                                   180045f4d(W), 
                                                                                                   1800462d0(W)  
             bool              AL:1           leftUpdated                             XREF[3]:     180045d36(W), 
                                                                                                   180045f4d(W), 
                                                                                                   1800462d0(W)  
             ulonglong         R15:8          rightElementULL                         XREF[2]:     180045e18(W), 
                                                                                                   180046123(W)  
             float             XMM0_Da:4      massDifference$1                        XREF[1]:     180045f01(W)  
             int               EBP:4          diseaseCountToMove$2                    XREF[2]:     180045f49(W), 
                                                                                                   180046295(W)  
             bool              AL:1           downImpermeable$1                       XREF[2]:     180045f4d(W), 
                                                                                                   1800462d0(W)  
             int               R15D:4         upCellIdx                               XREF[1]:     180046123(W)  
             ulonglong         R9:8           upCellIdxULL                            XREF[1]:     180046126(W)  
             float             XMM2_Da:4      massDifferece                           XREF[2]:     18004622f(W), 
                                                                                                   18004623f(W)  
             float             XMM2_Da:4      movableAmount$2                         XREF[1]:     18004623f(W)  
             int               EBP:4          diseaseCountToMove$3                    XREF[1]:     180046295(W)  
             bool              AL:1           succeededToMove                         XREF[1]:     1800462d0(W)  
             int               R14D:4         downCellIdx$1                           XREF[1]:     18004638c(W)  
             ulonglong         R10:8          downCellIdxULL                          XREF[1]:     18004638f(W)  
             undefined4        Stack[0x20]:4  local_res20                             XREF[2]:     180045623(W), 
                                                                                                   1800456a4(R)  
             undefined4        Stack[0x18]:4  local_res18                             XREF[9]:     180045585(W), 
                                                                                                   1800456b4(R), 
                                                                                                   1800458da(R), 
                                                                                                   180045d0f(R), 
                                                                                                   180045ddf(R), 
                                                                                                   180046034(R), 
                                                                                                   1800461a1(R), 
                                                                                                   1800463a1(W), 
                                                                                                   1800464a8(R)  
             undefined8        Stack[0x10]:8  local_res10                             XREF[11]:    180045513(W), 
                                                                                                   18004578a(R), 
                                                                                                   180045a3a(R), 
                                                                                                   180045aff(R), 
                                                                                                   180045b15(R), 
                                                                                                   180045caf(R), 
                                                                                                   180045ce5(R), 
                                                                                                   180045fec(R), 
                                                                                                   180046040(R), 
                                                                                                   1800462aa(R), 
                                                                                                   1800465ae(R)  
             undefined4        Stack[0x8]:4   cellDiseaseCount                        XREF[9]:     18004560a(W), 
                                                                                                   180045731(R), 
                                                                                                   1800457ab(W), 
                                                                                                   180045a4b(R), 
                                                                                                   180045bfc(R), 
                                                                                                   180045d47(RW), 
                                                                                                   180045f23(R), 
                                                                                                   180046071(RW), 
                                                                                                   18004626d(R)  
             undefined1        Stack[-0x40]:1 local_40                                XREF[1]:     180045b25(*)  
             undefined1[16]    Stack[-0x58]   local_58                                XREF[2]:     180045531(W), 
                                                                                                   180045b2d(R)  
             undefined1[16]    Stack[-0x68]   local_68                                XREF[2]:     180045535(W), 
                                                                                                   180045b32(R)  
             undefined1[16]    Stack[-0x78]   local_78                                XREF[2]:     180045539(W), 
                                                                                                   180045b37(R)  
             undefined1[16]    Stack[-0x88]   local_88                                XREF[2]:     18004554c(W), 
                                                                                                   180045b3c(R)  
             undefined1[16]    Stack[-0x98]   local_98                                XREF[2]:     18004555a(W), 
                                                                                                   180045b41(R)  
             undefined1[16]    Stack[-0xa8]   local_a8                                XREF[2]:     180045560(W), 
                                                                                                   180045b46(R)  
             undefined8        Stack[-0xb8]:8 local_b8                                XREF[5]:     1800455c7(W), 
                                                                                                   1800456e3(R), 
                                                                                                   180045bc6(R), 
                                                                                                   180045eed(R), 
                                                                                                   18004621d(R)  
             undefined4        Stack[-0xc8]:4 local_c8                                XREF[7]:     180045772(W), 
                                                                                                   180045a47(W), 
                                                                                                   180045cbc(W), 
                                                                                                   180045d1b(W), 
                                                                                                   180045fe0(W), 
                                                                                                   180046048(W), 
                                                                                                   1800462b5(W)  
             undefined4        Stack[-0xd0]:4 local_d0                                XREF[7]:     180045779(W), 
                                                                                                   180045a52(W), 
                                                                                                   180045cc0(W), 
                                                                                                   180045d22(W), 
                                                                                                   180045fe4(W), 
                                                                                                   18004604c(W), 
                                                                                                   1800462bc(W)  
             undefined4        Stack[-0xd8]:4 local_d8                                XREF[7]:     180045780(W), 
                                                                                                   180045a56(W), 
                                                                                                   180045cc4(W), 
                                                                                                   180045d26(W), 
                                                                                                   180045fe8(W), 
                                                                                                   180046050(W), 
                                                                                                   1800462c0(W)  
             undefined4        Stack[-0xe0]:4 local_e0                                XREF[7]:     180045786(W), 
                                                                                                   180045a5d(W), 
                                                                                                   180045ccb(W), 
                                                                                                   180045d2c(W), 
                                                                                                   180045ff4(W), 
                                                                                                   180046056(W), 
                                                                                                   1800462c6(W)  
             undefined4        Stack[-0xe8]:4 local_e8                                XREF[7]:     180045792(W), 
                                                                                                   180045a63(W), 
                                                                                                   180045cd4(W), 
                                                                                                   180045d31(W), 
                                                                                                   180045ffd(W), 
                                                                                                   18004605b(W), 
                                                                                                   1800462cb(W)  
             CellSOA *         HASH:5f4d5c2   cells
             undefined8        HASH:5f90216   elementIdx
             undefined2        HASH:5f50c9f   cellElementIdx
             undefined8        HASH:45f5bdf   elementLiquidDataSize
             ElementLiquidD    HASH:27f733e   elementLiquidDataPtr
             undefined8        HASH:5f232b2   diseaseCountPtr
             undefined8        HASH:5f5faf5   cells$1
             undefined8        HASH:5fd17ec   elementIdx$1
             uchar *           HASH:5f5a287   properties
             undefined4        HASH:5f17aa2   amountToMove
             undefined4        HASH:3f808b3   compressedCellMas
             float             HASH:3f340a6   movableAmount
             CellSOA *         HASH:5f20965   updateCells
             undefined8        HASH:5f193a9   diseaseIdx
             undefined8        HASH:5f30fac   oldDiseaseIdx
             float *           HASH:5ff493c   flow
             ulonglong         HASH:27fea7a   leftIndex1
             undefined2        HASH:5fdca44   leftElement
             undefined8        HASH:5fd2e10   updatedCells$1
             short *           HASH:5fc173e   updatedElementIdx
             ulonglong         HASH:45ffeb9   liquidDataSize
             uchar *           HASH:5f95b7e   properties$1
             float             HASH:5faf02f   leftCellMass
             float *           HASH:5fd6158   temperature$1
             CellSOA *         HASH:5fc4aa4   updatedCells
             undefined8        HASH:5f4c5a1   mass
             float *           HASH:5f7b0da   temperature
             int               HASH:5f941dd   width
             float *           HASH:5f9a9d6   temperature$2
             undefined8        HASH:5fd7a4d   flow$1
             ulonglong         HASH:27f85c7   rightIndex
             ushort            HASH:5fd693b   rightElement
             uchar *           HASH:5fc1907   properties$2
             float             HASH:5fb6bf1   rightMass
             int               HASH:5f511fc   width$1
             ushort            HASH:5f7bef1   upElement
             uchar *           HASH:5f4ed00   properties$3
             float             HASH:5fedfe7   upCellMass
             float             HASH:3fedf4e   expectedCellMass
             CellSOA *         HASH:5f07074   updatedCells$2
             CellSOA *         HASH:5f6f0cb   updatedCells$3
             int               HASH:27ffedb   downRightCellIdx
             ulonglong         HASH:27f386a   downRightCellIdxULL
             uchar *           HASH:5fbfd69   properties$4
                             ?UpdateLiquid@@YAXAEAVSimData@@AEAUSimEvents@@  XREF[2]:     UpdateData:1800431e8(c), 
                             UpdateLiquid                                                 1800d2a24(*)  
       180045510 48 8b c4        MOV        RAX,RSP
       180045513 48 89 50 10     MOV        qword ptr [RAX + local_res10],simEvent
       180045517 53              PUSH       RBX
       180045518 55              PUSH       RBP
       180045519 56              PUSH       RSI
       18004551a 57              PUSH       RDI
       18004551b 41 54           PUSH       R12
       18004551d 41 55           PUSH       R13
       18004551f 41 56           PUSH       R14
       180045521 41 57           PUSH       R15
       180045523 48 81 ec        SUB        RSP,0xc8
                 c8 00 00 00
       18004552a 48 8b 71 18     MOV        RSI,qword ptr [RCX + simData->cells.pointer]
       18004552e 48 8b f9        MOV        RDI,simData
       180045531 0f 29 70 a8     MOVAPS     xmmword ptr [RAX + local_58[0]],XMM6
       180045535 0f 29 78 98     MOVAPS     xmmword ptr [RAX + local_68[0]],XMM7
       180045539 44 0f 29        MOVAPS     xmmword ptr [RAX + local_78[0]],XMM8
                 40 88
       18004553e 4c 8b 5e 08     MOV        R11,qword ptr [RSI + 0x8]
       180045542 4c 8b 4e 10     MOV        R9,qword ptr [RSI + 0x10]
       180045546 4d 2b cb        SUB        R9,R11
       180045549 4d 63 e8        MOVSXD     cellIndexLL,cellIndex
       18004554c 44 0f 29        MOVAPS     xmmword ptr [RAX + local_88[0]],XMM9
                 88 78 ff 
                 ff ff
       180045554 49 8b dd        MOV        RBX,cellIndexLL
       180045557 49 d1 f9        SAR        R9,0x1
       18004555a 44 0f 29        MOVAPS     xmmword ptr [RSP + local_98[0]],XMM10
                 54 24 70
       180045560 44 0f 29        MOVAPS     xmmword ptr [RSP + local_a8[0]],XMM11
                 5c 24 60
       180045566 4d 3b e9        CMP        cellIndexLL,R9
       180045569 0f 83 5a        JNC        LAB_IndexOutOfBounds
                 10 00 00
       18004556f 43 0f b7        MOVZX      EAX,word ptr [R11 + cellIndexLL*0x2]
                 04 6b
       180045574 48 8b 0d        MOV        simData,qword ptr [gElementLiquidData.field16_
                 65 7a 08 00
       18004557b 44 8b d0        MOV        R10D,EAX
       18004557e 4c 8b 05        MOV        cellIndex,qword ptr [gElementLiquidData.field8
                 53 7a 08 00
       180045585 66 89 84        MOV        word ptr [RSP + local_res18],AX
                 24 20 01 
                 00 00
       18004558d 49 2b c8        SUB        simData,cellIndex
       180045590 48 b8 ab        MOV        RAX,0x2aaaaaaaaaaaaaab
                 aa aa aa 
                 aa aa aa 2a
       18004559a 48 f7 e9        IMUL       simData
       18004559d 48 c1 fa 02     SAR        simEvent,0x2
       1800455a1 48 8b c2        MOV        RAX,simEvent
       1800455a4 48 c1 e8 3f     SHR        RAX,0x3f
       1800455a8 48 03 d0        ADD        simEvent,RAX
       1800455ab 4c 3b d2        CMP        R10,simEvent
       1800455ae 0f 83 15        JNC        LAB_IndexOutOfBounds
                 10 00 00
       1800455b4 4c 8b 7e 48     MOV        R15,qword ptr [RSI + 0x48]
       1800455b8 4b 8d 04 52     LEA        RAX,[R10 + R10*0x2]
       1800455bc 4c 8b 56 50     MOV        R10,qword ptr [RSI + 0x50]
       1800455c0 49 8d 0c c0     LEA        simData,[cellIndex + RAX*0x8]
       1800455c4 4d 2b d7        SUB        R10,R15
       1800455c7 48 89 4c        MOV        qword ptr [RSP + local_b8],simData
                 24 50
       1800455cc 49 c1 fa 02     SAR        massSize,0x2
       1800455d0 49 3b da        CMP        RBX,massSize
       1800455d3 0f 83 f0        JNC        LAB_IndexOutOfBounds
                 0f 00 00
       1800455d9 48 8b 8e        MOV        simData,qword ptr [RSI + 0xe8]
                 e8 00 00 00
       1800455e0 48 8b 86        MOV        RAX,qword ptr [RSI + 0xf0]
                 f0 00 00 00
       1800455e7 f3 43 0f        MOVSS      XMM6,dword ptr [R15 + cellIndexLL*0x4]
                 10 34 af
       1800455ed 48 2b c1        SUB        RAX,simData
       1800455f0 48 c1 f8 02     SAR        RAX,0x2
       1800455f4 48 3b d8        CMP        RBX,RAX
       1800455f7 0f 83 cc        JNC        LAB_IndexOutOfBounds
                 0f 00 00
       1800455fd 42 8b 04 a9     MOV        EAX,dword ptr [simData->width + cellIndexLL*0x4]
       180045601 45 8b f5        MOV        R14D,cellIndexLL
       180045604 44 2b 37        SUB        downCellIdx,dword ptr [RDI]
       180045607 49 63 ee        MOVSXD     downCellIndexUL,downCellIdx
       18004560a 89 84 24        MOV        dword ptr [RSP + cellDiseaseCount],EAX
                 10 01 00 00
       180045611 49 3b e9        CMP        downCellIndexUL,R9
       180045614 0f 83 af        JNC        LAB_IndexOutOfBounds
                 0f 00 00
       18004561a 48 8b 47 20     MOV        RAX,qword ptr [RDI + 0x20]
       18004561e 41 0f b7        MOVZX      simData,word ptr [R11 + downCellIndexUL*0x2]
                 0c 6b
       180045623 89 8c 24        MOV        dword ptr [RSP + local_res20],downCellElementIdx
                 28 01 00 00
       18004562a 4c 8b 58 08     MOV        R11,qword ptr [RAX + 0x8]
       18004562e 4c 8b 48 10     MOV        R9,qword ptr [RAX + 0x10]
       180045632 4d 2b cb        SUB        R9,R11
       180045635 49 d1 f9        SAR        elementIdxSize,0x1
       180045638 49 3b e9        CMP        downCellIndexUL,elementIdxSize
       18004563b 0f 83 88        JNC        LAB_IndexOutOfBounds
                 0f 00 00
       180045641 44 8b e1        MOV        R12D,downCellElementIdx
       180045644 48 3b ca        CMP        downCellElementIdx,simEvent
       180045647 0f 83 7c        JNC        LAB_IndexOutOfBounds
                 0f 00 00
       18004564d 41 0f b7        MOVZX      EAX,word ptr [R11 + downCellIndexUL*0x2]
                 04 6b
       180045652 48 3b c2        CMP        RAX,simEvent
       180045655 0f 83 6e        JNC        LAB_IndexOutOfBounds
                 0f 00 00
       18004565b f3 44 0f        MOVSS      XMM10,dword ptr [__real@3f8147ae]                = 3F8147AEh
                 10 15 94 
                 68 05 00
       180045664 48 8d 04 40     LEA        RAX,[RAX + RAX*0x2]
       180045668 41 0f b6        MOVZX      downCellElementIdx,byte ptr [cellIndex + RAX*0
                 0c c0
       18004566d 45 0f 57 c0     XORPS      XMM8,XMM8
       180045671 f3 44 0f        MOVSS      XMM11,dword ptr [__real@3f000000]                = 3F000000h
                 10 1d 46 
                 08 05 00
       18004567a 80 e1 03        AND        downCellElementIdx,0x3
       18004567d 80 f9 03        CMP        downCellElementIdx,0x3
       180045680 0f 84 c7        JZ         LAB_18004584d
                 01 00 00
                             真下が固体以外
       180045686 48 8b 4e 68     MOV        downCellElementIdx,qword ptr [RSI + 0x68]
       18004568a 48 8b 46 70     MOV        RAX,qword ptr [RSI + 0x70]
       18004568e 48 2b c1        SUB        RAX,downCellElementIdx
       180045691 48 3b e8        CMP        downCellIndexUL,RAX
       180045694 0f 83 2f        JNC        LAB_IndexOutOfBounds
                 0f 00 00
       18004569a f6 04 29 02     TEST       byte ptr [downCellElementIdx + downCellIndexUL
       18004569e 0f 85 a9        JNZ        LAB_18004584d
                 01 00 00
       1800456a4 8b 94 24        MOV        simEvent,dword ptr [RSP + local_res20]
                 28 01 00 00
       1800456ab 4b 8d 04 64     LEA        RAX,[R12 + R12*0x2]
                             真下が流体を通すブロック
       1800456af 41 0f b6        MOVZX      downCellElementIdx,byte ptr [cellIndex + RAX*0
                 0c c0
       1800456b4 0f b7 84        MOVZX      EAX,word ptr [RSP + local_res18]
                 24 20 01 
                 00 00
       1800456bc 80 e1 03        AND        downState,0x3
       1800456bf 44 8b e0        MOV        R12D,EAX
       1800456c2 3b c2           CMP        EAX,simEvent
       1800456c4 0f 85 98        JNZ        LAB_180045962
                 02 00 00
                             真下が同一Element
       1800456ca 80 f9 02        CMP        downState,0x2
       1800456cd 75 11           JNZ        LAB_1800456e0
                             真下が液体
       1800456cf 49 3b ea        CMP        downCellIndexUL,massSize
       1800456d2 0f 83 f1        JNC        LAB_IndexOutOfBounds
                 0e 00 00
       1800456d8 f3 41 0f        MOVSS      XMM1,dword ptr [R15 + downCellIndexUL*0x4]
                 10 0c af
       1800456de eb 03           JMP        LAB_1800456e3
                             LAB_1800456e0                                   XREF[1]:     1800456cd(j)  
       1800456e0 0f 57 c9        XORPS      XMM1,XMM1
                             LAB_1800456e3                                   XREF[1]:     1800456de(j)  
       1800456e3 48 8b 44        MOV        RAX,qword ptr [RSP + local_b8]
                 24 50
       1800456e8 0f 28 c6        MOVAPS     XMM0,XMM6
                             1.01は縦方向の流体圧縮係数（全流体で共通）
       1800456eb f3 41 0f        MULSS      XMM0,XMM10
                 59 c2
       1800456f0 f3 0f 10        MOVSS      XMM7,dword ptr [RAX + 0x8]
                 78 08
       1800456f5 0f 2f fe        COMISS     XMM7,XMM6
       1800456f8 f3 0f 5f        MAXSS      XMM0,dword ptr [RAX + 0x14]
                 40 14
       1800456fd f3 0f 5c c1     SUBSS      massDifference,XMM1
       180045701 f3 41 0f        MAXSS      massDifference,XMM8
                 5f c0
       180045706 f3 41 0f        MULSS      massDifference,XMM11
                 59 c3
       18004570b 72 03           JC         LAB_180045710
       18004570d 0f 28 fe        MOVAPS     XMM7,XMM6
                             LAB_180045710                                   XREF[1]:     18004570b(j)  
       180045710 f3 0f 10        MOVSS      XMM1,dword ptr [RAX + 0x10]
                 48 10
       180045715 f3 0f 5d f8     MINSS      XMM7,massDifference
       180045719 0f 2f f1        COMISS     XMM6,XMM1
       18004571c 76 09           JBE        LAB_180045727
       18004571e 0f 2f f9        COMISS     XMM7,XMM1
       180045721 0f 82 26        JC         LAB_18004584d
                 01 00 00
                             LAB_180045727                                   XREF[1]:     18004571c(j)  
       180045727 41 0f 2f f8     COMISS     XMM7,XMM8
       18004572b 0f 86 1c        JBE        LAB_18004584d
                 01 00 00
       180045731 44 8b bc        MOV        R15D,dword ptr [RSP + cellDiseaseCount]
                 24 10 01 
                 00 00
       180045739 0f 28 cf        MOVAPS     XMM1,XMM7
                             自分の質量がminVerticalFlow以下または下へ移動する量がminVerticalFl
                             落下
       18004573c 48 8b 8e        MOV        downState,qword ptr [RSI + 0xc8]
                 c8 00 00 00
       180045743 48 8b 86        MOV        RAX,qword ptr [RSI + 0xd0]
                 d0 00 00 00
       18004574a f3 0f 5e ce     DIVSS      XMM1,XMM6
       18004574e 48 2b c1        SUB        RAX,downState
       180045751 66 41 0f        MOVD       massDifference,R15D
                 6e c7
       180045756 0f 5b c0        CVTDQ2PS   massDifference,massDifference
       180045759 f3 0f 59 c8     MULSS      XMM1,massDifference
       18004575d f3 0f 2c e9     CVTTSS2SI  diseaseCountToMove,XMM1
       180045761 48 3b d8        CMP        RBX,RAX
       180045764 0f 83 5f        JNC        LAB_IndexOutOfBounds
                 0e 00 00
       18004576a 42 0f b6        MOVZX      EAX,byte ptr [downState + cellIndexLL*0x1]
                 04 29
       18004576f 45 8b cc        MOV        elementIdxSize,R12D
       180045772 89 6c 24 40     MOV        dword ptr [RSP + local_c8],diseaseCountToMove
       180045776 45 8b c5        MOV        cellIndex,cellIndexLL
       180045779 88 44 24 38     MOV        byte ptr [RSP + local_d0],AL
       18004577d 48 8b cf        MOV        downState,RDI
       180045780 f3 0f 11        MOVSS      dword ptr [RSP + local_d8],XMM7
                 7c 24 30
       180045786 89 54 24 28     MOV        dword ptr [RSP + local_e0],simEvent
       18004578a 48 8b 94        MOV        simEvent,qword ptr [RSP + local_res10]
                 24 18 01 
                 00 00
       180045792 44 89 74        MOV        dword ptr [RSP + local_e8],downCellIdx
                 24 20
       180045797 e8 34 0e        CALL       UpdateNeighbourLiquidMass                        bool UpdateNeighbourLiquidMass(S
                 00 00
       18004579c 84 c0           TEST       success,success
       18004579e 0f 84 a2        JZ         LAB_180045846
                 00 00 00
                             下のブロックを更新できたら自分（disease,mass,flow）も更新
       1800457a4 48 8b 4f 20     MOV        downState,qword ptr [RDI + 0x20]
       1800457a8 44 2b fd        SUB        R15D,diseaseCountToMove
       1800457ab 44 89 bc        MOV        dword ptr [RSP + cellDiseaseCount],R15D
                 24 10 01 
                 00 00
       1800457b3 48 8b 91        MOV        simEvent,qword ptr [downState + 0xc8]
                 c8 00 00 00
       1800457ba 48 8b 81        MOV        success,qword ptr [downState + 0xd0]
                 d0 00 00 00
       1800457c1 48 2b c2        SUB        success,simEvent
       1800457c4 48 3b d8        CMP        RBX,success
       1800457c7 0f 83 fc        JNC        LAB_IndexOutOfBounds
                 0d 00 00
       1800457cd 4c 8b 86        MOV        cellIndex,qword ptr [RSI + 0xc8]
                 c8 00 00 00
       1800457d4 48 8b 86        MOV        success,qword ptr [RSI + 0xd0]
                 d0 00 00 00
       1800457db 49 2b c0        SUB        success,cellIndex
       1800457de 48 3b d8        CMP        RBX,success
       1800457e1 0f 83 e2        JNC        LAB_IndexOutOfBounds
                 0d 00 00
       1800457e7 43 0f b6        MOVZX      success,byte ptr [cellIndex + cellIndexLL*0x1]
                 04 28
       1800457ec 41 38 44        CMP        byte ptr [cellIndexLL + simEvent->substanceCha
                 15 00
       1800457f1 75 11           JNZ        LAB_180045804
       1800457f3 f7 dd           NEG        diseaseCountToMove
       1800457f5 41 8b d5        MOV        simEvent,cellIndexLL
       1800457f8 44 8b c5        MOV        cellIndex,diseaseCountToMove
                             感染症の種類が同じ場合に限り更新
       1800457fb e8 00 fb        CALL       CellSOA::ModifyDiseaseCount                      void ModifyDiseaseCount(CellSOA 
                 ff ff
       180045800 48 8b 4f 20     MOV        downState,qword ptr [RDI + 0x20]
                             LAB_180045804                                   XREF[1]:     1800457f1(j)  
       180045804 48 8b 51 48     MOV        simEvent,qword ptr [downState + 0x48]
       180045808 f3 0f 5c f7     SUBSS      cellMass,XMM7
       18004580c 48 8b 41 50     MOV        success,qword ptr [downState + 0x50]
       180045810 48 2b c2        SUB        success,simEvent
       180045813 48 c1 f8 02     SAR        success,0x2
       180045817 48 3b d8        CMP        RBX,success
       18004581a 0f 83 a9        JNC        LAB_IndexOutOfBounds
                 0d 00 00
       180045820 f3 42 0f        MOVSS      massDifference,dword ptr [simEvent->substanceC
                 10 04 aa
       180045826 48 8b cb        MOV        downState,RBX
       180045829 48 8b 47 58     MOV        success,qword ptr [RDI + 0x58]
       18004582d f3 0f 5c c7     SUBSS      massDifference,XMM7
       180045831 48 03 c9        ADD        downState,downState
       180045834 f3 42 0f        MOVSS      dword ptr [simEvent->substanceChangeInfo.field
                 11 04 aa
       18004583a f3 0f 58        ADDSS      XMM7,dword ptr [success + downState*0x8 + 0x8]
                 7c c8 08
       180045840 f3 0f 11        MOVSS      dword ptr [success + downState*0x8 + 0x8],XMM7
                 7c c8 08
                             LAB_180045846                                   XREF[1]:     18004579e(j)  
       180045846 4c 8b 05        MOV        cellIndex,qword ptr [gElementLiquidData.field8
                 8b 77 08 00
                             LAB_18004584d                                   XREF[5]:     180045680(j), 18004569e(j), 
                                                                                          180045721(j), 18004572b(j), 
                                                                                          180045965(j)  
       18004584d 41 0f 2f f0     COMISS     cellMass,XMM8
                             End If真下が固体以外
       180045851 0f 86 ce        JBE        LAB_180045b25
                 02 00 00
       180045857 4c 8b 4f 18     MOV        elementIdxSize,qword ptr [RDI + 0x18]
       18004585b 49 8d 6d ff     LEA        diseaseCountToMove,[cellIndexLL + -0x1]
       18004585f 45 8d 65 ff     LEA        leftIndex2,[cellIndexLL + -0x1]
       180045863 49 8b 49 08     MOV        downState,qword ptr [elementIdxSize + 0x8]
       180045867 49 8b 41 10     MOV        success,qword ptr [elementIdxSize + 0x10]
       18004586b 48 2b c1        SUB        success,downState
       18004586e 48 d1 f8        SAR        success,0x1
       180045871 48 3b e8        CMP        diseaseCountToMove,success
       180045874 0f 83 4f        JNC        LAB_IndexOutOfBounds
                 0d 00 00
       18004587a 44 0f b7        MOVZX      leftElementULL,word ptr [downState + diseaseCo
                 3c 69
       18004587f 48 8b 47 20     MOV        success,qword ptr [RDI + 0x20]
       180045883 4c 8b 58 08     MOV        R11,qword ptr [success + 0x8]
       180045887 48 8b 48 10     MOV        downState,qword ptr [success + 0x10]
       18004588b 49 2b cb        SUB        downState,R11
       18004588e 48 d1 f9        SAR        downState,0x1
       180045891 48 3b e9        CMP        diseaseCountToMove,downState
       180045894 0f 83 2f        JNC        LAB_IndexOutOfBounds
                 0d 00 00
       18004589a 48 8b 0d        MOV        downState,qword ptr [gElementLiquidData.field1
                 3f 77 08 00
       1800458a1 48 b8 ab        MOV        success,0x2aaaaaaaaaaaaaab
                 aa aa aa 
                 aa aa aa 2a
       1800458ab 49 2b c8        SUB        downState,cellIndex
       1800458ae 48 f7 e9        IMUL       downState
       1800458b1 48 c1 fa 02     SAR        simEvent,0x2
       1800458b5 48 8b c2        MOV        success,simEvent
       1800458b8 48 c1 e8 3f     SHR        success,0x3f
       1800458bc 48 03 d0        ADD        simEvent,success
       1800458bf 4c 3b fa        CMP        leftElementULL,simEvent
       1800458c2 0f 83 01        JNC        LAB_IndexOutOfBounds
                 0d 00 00
       1800458c8 41 0f b7        MOVZX      updatedLeftElement,word ptr [R11 + diseaseCoun
                 04 6b
       1800458cd 4f 8d 14 7f     LEA        massSize,[R15 + R15*0x2]
       1800458d1 48 3b c2        CMP        updatedLeftElement,simEvent
       1800458d4 0f 83 ef        JNC        LAB_IndexOutOfBounds
                 0c 00 00
       1800458da 44 0f b7        MOVZX      downCellIdx,word ptr [RSP + local_res18]
                 b4 24 20 
                 01 00 00
       1800458e3 48 8d 0c 40     LEA        downState,[RAX + RAX*0x2]
       1800458e7 f3 44 0f        MOVSS      XMM9,dword ptr [__real@3e800000]                 = 3E800000h
                 10 0d 84 
                 54 05 00
       1800458f0 45 3b f7        CMP        downCellIdx,leftElementULL
       1800458f3 74 0f           JZ         LAB_180045904
       1800458f5 43 0f b6        MOVZX      updatedLeftElement,byte ptr [cellIndex + massS
                 04 d0
       1800458fa 24 03           AND        updatedLeftElement,0x3
       1800458fc 3c 01           CMP        updatedLeftElement,0x1
       1800458fe 0f 87 eb        JA         LAB_180045def
                 04 00 00
                             LAB_180045904                                   XREF[1]:     1800458f3(j)  
       180045904 41 0f b6        MOVZX      updatedLeftElement,byte ptr [cellIndex + downS
                 04 c8
       180045909 24 03           AND        updatedLeftElement,0x3
       18004590b 3c 03           CMP        updatedLeftElement,0x3
       18004590d 0f 84 dc        JZ         LAB_180045def
                 04 00 00
                             左が同じ元素か真空か気体かつ左の次の状態が固体でないなら
       180045913 49 8b 49 68     MOV        downState,qword ptr [elementIdxSize + 0x68]
       180045917 49 8b 41 70     MOV        updatedLeftElement,qword ptr [elementIdxSize +
       18004591b 48 2b c1        SUB        updatedLeftElement,downState
       18004591e 48 3b e8        CMP        diseaseCountToMove,updatedLeftElement
       180045921 0f 83 a2        JNC        LAB_IndexOutOfBounds
                 0c 00 00
       180045927 f6 04 29 02     TEST       byte ptr [downState + diseaseCountToMove*0x1],
       18004592b 0f 85 be        JNZ        LAB_180045def
                 04 00 00
                             左は液体が通れる
       180045931 43 0f b6        MOVZX      updatedLeftElement,byte ptr [cellIndex + massS
                 04 d0
       180045936 24 03           AND        updatedLeftElement,0x3
       180045938 3c 02           CMP        updatedLeftElement,0x2
       18004593a 0f 85 83        JNZ        LAB_180045bc3
                 02 00 00
                             左が液体
       180045940 49 8b 49 48     MOV        downState,qword ptr [elementIdxSize + 0x48]
       180045944 49 8b 41 50     MOV        updatedLeftElement,qword ptr [elementIdxSize +
       180045948 48 2b c1        SUB        updatedLeftElement,downState
       18004594b 48 c1 f8 02     SAR        updatedLeftElement,0x2
       18004594f 48 3b e8        CMP        diseaseCountToMove,updatedLeftElement
       180045952 0f 83 71        JNC        LAB_IndexOutOfBounds
                 0c 00 00
       180045958 f3 0f 10        MOVSS      XMM1,dword ptr [downState + diseaseCountToMove
                 0c a9
       18004595d e9 64 02        JMP        LAB_180045bc6
                 00 00
                             LAB_180045962                                   XREF[1]:     1800456c4(j)  
       180045962 80 f9 01        CMP        downState,0x1
                             真下が同一Elementじゃなかった
       180045965 0f 87 e2        JA         LAB_18004584d
                 fe ff ff
       18004596b 0f b7 47 0e     MOVZX      updatedLeftElement,word ptr [RDI + 0xe]
                             真空か気体
       18004596f 3b d0           CMP        simEvent,updatedLeftElement
       180045971 0f 84 e4        JZ         LAB_180045b5b
                 01 00 00
       180045977 48 8b 4f 20     MOV        downState,qword ptr [RDI + 0x20]
       18004597b 41 8d 45 01     LEA        updatedLeftElement,[cellIndexLL + 0x1]
       18004597f 4c 63 f8        MOVSXD     leftElementULL,updatedLeftElement
       180045982 41 8d 46 01     LEA        updatedLeftElement,[downCellIdx + 0x1]
       180045986 4c 63 e0        MOVSXD     leftIndex2,updatedLeftElement
       180045989 41 8d 45 ff     LEA        updatedLeftElement,[cellIndexLL + -0x1]
       18004598d 48 63 d0        MOVSXD     simEvent,updatedLeftElement
       180045990 e8 4b f8        CALL       IsLiquidPermeable                                bool IsLiquidPermeable(CellSOA *
                 ff ff
       180045995 84 c0           TEST       leftPermeable,leftPermeable
       180045997 74 14           JZ         LAB_1800459ad
       180045999 48 8b 4f 20     MOV        downState,qword ptr [RDI + 0x20]
       18004599d 41 8d 46 ff     LEA        leftPermeable,[downCellIdx + -0x1]
       1800459a1 48 63 d0        MOVSXD     simEvent,leftPermeable
       1800459a4 e8 37 f8        CALL       IsLiquidPermeable                                bool IsLiquidPermeable(CellSOA *
                 ff ff
       1800459a9 84 c0           TEST       downLeftPermeable,downLeftPermeable
       1800459ab 74 28           JZ         LAB_1800459d5
                             LAB_1800459ad                                   XREF[1]:     180045997(j)  
       1800459ad 48 8b 4f 20     MOV        downState,qword ptr [RDI + 0x20]
       1800459b1 49 8b d7        MOV        simEvent,leftElementULL
       1800459b4 e8 27 f8        CALL       IsLiquidPermeable                                bool IsLiquidPermeable(CellSOA *
                 ff ff
       1800459b9 84 c0           TEST       rightPermeable,rightPermeable
       1800459bb 0f 84 2f        JZ         LAB_180045af0
                 01 00 00
       1800459c1 48 8b 4f 20     MOV        downState,qword ptr [RDI + 0x20]
       1800459c5 49 8b d4        MOV        simEvent,leftIndex2
       1800459c8 e8 13 f8        CALL       IsLiquidPermeable                                bool IsLiquidPermeable(CellSOA *
                 ff ff
       1800459cd 84 c0           TEST       downRightPermeable,downRightPermeable
       1800459cf 0f 85 1b        JNZ        LAB_180045af0
                 01 00 00
                             左か右に流れられるが、その下は流れられない（＝崖端）なら液体落下パーテ
                             LAB_1800459d5                                   XREF[1]:     1800459ab(j)  
       1800459d5 48 8b 96        MOV        simEvent,qword ptr [RSI + 0xc8]
                 c8 00 00 00
       1800459dc 48 8b 86        MOV        downRightPermeable,qword ptr [RSI + 0xd0]
                 d0 00 00 00
       1800459e3 48 2b c2        SUB        downRightPermeable,simEvent
       1800459e6 48 3b d8        CMP        RBX,downRightPermeable
       1800459e9 0f 83 da        JNC        LAB_IndexOutOfBounds
                 0b 00 00
       1800459ef 48 8b 4f 18     MOV        downState,qword ptr [RDI + 0x18]
       1800459f3 4c 8b 41 28     MOV        cellIndex,qword ptr [downState + 0x28]
       1800459f7 48 8b 41 30     MOV        downRightPermeable,qword ptr [downState + 0x30]
       1800459fb 49 2b c0        SUB        downRightPermeable,cellIndex
       1800459fe 48 c1 f8 02     SAR        downRightPermeable,0x2
       180045a02 48 3b d8        CMP        RBX,downRightPermeable
       180045a05 0f 83 be        JNC        LAB_IndexOutOfBounds
                 0b 00 00
       180045a0b 4c 8b 49 08     MOV        elementIdxSize,qword ptr [downState + 0x8]
       180045a0f 48 8b 41 10     MOV        downRightPermeable,qword ptr [downState + 0x10]
       180045a13 49 2b c1        SUB        downRightPermeable,elementIdxSize
       180045a16 48 d1 f8        SAR        downRightPermeable,0x1
       180045a19 48 3b d8        CMP        RBX,downRightPermeable
       180045a1c 0f 83 a7        JNC        LAB_IndexOutOfBounds
                 0b 00 00
       180045a22 42 0f b6        MOVZX      downState,byte ptr [simEvent->substanceChangeI
                 0c 2a
       180045a27 48 8b d7        MOV        simEvent,RDI
       180045a2a 0f b6 87        MOVZX      downRightPermeable,byte ptr [RDI + 0xb4]
                 b4 00 00 00
       180045a31 f3 43 0f        MOVSS      massDifference,dword ptr [cellIndex + cellInde
                 10 04 a8
       180045a37 4c 8b c3        MOV        cellIndex,RBX
       180045a3a 48 8b b4        MOV        RSI,qword ptr [RSP + local_res10]
                 24 18 01 
                 00 00
       180045a42 47 0f b7        MOVZX      elementIdxSize,word ptr [elementIdxSize + cell
                 0c 69
       180045a47 88 44 24 40     MOV        byte ptr [RSP + local_c8],downRightPermeable
       180045a4b 8b 84 24        MOV        downRightPermeable,dword ptr [RSP + cellDiseas
                 10 01 00 00
       180045a52 89 44 24 38     MOV        dword ptr [RSP + local_d0],downRightPermeable
       180045a56 88 4c 24 30     MOV        byte ptr [RSP + local_d8],downState
       180045a5a 48 8b ce        MOV        downState,RSI
       180045a5d f3 0f 11        MOVSS      dword ptr [RSP + local_e0],massDifference
                 44 24 28
       180045a63 f3 0f 11        MOVSS      dword ptr [RSP + local_e8],cellMass
                 74 24 20
       180045a69 e8 f2 f8        CALL       SimEvents::SpawnFallingLiquid                    bool SpawnFallingLiquid(SimEvent
                 ff ff
       180045a6e 84 c0           TEST       downRightPermeable,downRightPermeable
       180045a70 0f 84 af        JZ         LAB_180045b25
                 00 00 00
       180045a76 48 8b 47 20     MOV        downRightPermeable,qword ptr [RDI + 0x20]
       180045a7a 48 8b 50 08     MOV        simEvent,qword ptr [downRightPermeable + 0x8]
       180045a7e 48 8b 48 10     MOV        downState,qword ptr [downRightPermeable + 0x10]
       180045a82 48 2b ca        SUB        downState,simEvent
       180045a85 48 d1 f9        SAR        downState,0x1
       180045a88 48 3b d9        CMP        RBX,downState
       180045a8b 0f 83 38        JNC        LAB_IndexOutOfBounds
                 0b 00 00
       180045a91 0f b7 47 10     MOVZX      downRightPermeable,word ptr [RDI + 0x10]
       180045a95 66 42 89        MOV        word ptr [simEvent->substanceChangeInfo.field0
                 04 6a
       180045a9a 48 8b 47 20     MOV        downRightPermeable,qword ptr [RDI + 0x20]
       180045a9e 4c 8b 40 28     MOV        cellIndex,qword ptr [downRightPermeable + 0x28]
       180045aa2 48 8b 48 30     MOV        downState,qword ptr [downRightPermeable + 0x30]
       180045aa6 49 2b c8        SUB        downState,cellIndex
       180045aa9 48 c1 f9 02     SAR        downState,0x2
       180045aad 48 3b d9        CMP        RBX,downState
       180045ab0 0f 83 13        JNC        LAB_IndexOutOfBounds
                 0b 00 00
       180045ab6 33 d2           XOR        simEvent,simEvent
       180045ab8 43 89 14 a8     MOV        dword ptr [cellIndex + cellIndexLL*0x4],simEvent
       180045abc 48 8b 47 20     MOV        downRightPermeable,qword ptr [RDI + 0x20]
       180045ac0 4c 8b 40 48     MOV        cellIndex,qword ptr [downRightPermeable + 0x48]
       180045ac4 48 8b 48 50     MOV        downState,qword ptr [downRightPermeable + 0x50]
       180045ac8 49 2b c8        SUB        downState,cellIndex
       180045acb 48 c1 f9 02     SAR        downState,0x2
       180045acf 48 3b d9        CMP        RBX,downState
       180045ad2 0f 83 f1        JNC        LAB_IndexOutOfBounds
                 0a 00 00
       180045ad8 43 89 14 a8     MOV        dword ptr [cellIndex + cellIndexLL*0x4],simEvent
       180045adc 41 8b d5        MOV        simEvent,cellIndexLL
       180045adf 48 8b 4f 20     MOV        downState,qword ptr [RDI + 0x20]
       180045ae3 e8 d8 f0        CALL       CellSOA::ClearDisease                            void ClearDisease(CellSOA * this
                 ff ff
       180045ae8 4c 8b c3        MOV        cellIndex,RBX
       180045aeb 48 8b ce        MOV        downState,RSI
       180045aee eb 2d           JMP        LAB_ChangeSubstanceAndReturn
                             LAB_180045af0                                   XREF[2]:     1800459bb(j), 1800459cf(j)  
       180045af0 48 8b 4f 20     MOV        downState,qword ptr [RDI + 0x20]
       180045af4 45 8b c6        MOV        cellIndex,downCellIdx
       180045af7 41 8b d5        MOV        simEvent,cellIndexLL
                             真下が真空か気体かつ崖端じゃないのでシンプルにスワップ
       180045afa e8 41 fc        CALL       CellSOA::SwapCells                               void SwapCells(CellSOA * this, i
                 fe ff
       180045aff 48 8b 8c        MOV        downState,qword ptr [RSP + local_res10]
                 24 18 01 
                 00 00
       180045b07 4c 8b c3        MOV        cellIndex,RBX
       180045b0a 48 8b d7        MOV        simEvent,RDI
       180045b0d e8 de cc        CALL       SimEvents::ChangeSubstance                       void ChangeSubstance(SimEvents *
                 fe ff
       180045b12 4c 8b c5        MOV        cellIndex,diseaseCountToMove
                             LAB_180045b15                                   XREF[2]:     180045bbe(j), 1800465c4(j)  
       180045b15 48 8b 8c        MOV        downState,qword ptr [RSP + local_res10]
                 24 18 01 
                 00 00
                             LAB_ChangeSubstanceAndReturn                    XREF[1]:     180045aee(j)  
       180045b1d 48 8b d7        MOV        simEvent,RDI
       180045b20 e8 cb cc        CALL       SimEvents::ChangeSubstance                       void ChangeSubstance(SimEvents *
                 fe ff
                             LAB_180045b25                                   XREF[11]:    180045851(j), 180045a70(j), 
                                                                                          180045df3(j), 180046116(j), 
                                                                                          18004637f(j), 1800464df(j), 
                                                                                          18004652b(j), 18004655e(j), 
                                                                                          18004657a(j), 180046589(j), 
                                                                                          180046599(j)  
       180045b25 4c 8d 9c        LEA        R11=>local_40,[RSP + 0xc8]
                 24 c8 00 
                 00 00
       180045b2d 41 0f 28        MOVAPS     cellMass,xmmword ptr [R11 + local_58[0]]
                 73 e8
       180045b32 41 0f 28        MOVAPS     XMM7,xmmword ptr [R11 + local_68[0]]
                 7b d8
       180045b37 45 0f 28        MOVAPS     XMM8,xmmword ptr [R11 + local_78[0]]
                 43 c8
       180045b3c 45 0f 28        MOVAPS     XMM9,xmmword ptr [R11 + local_88[0]]
                 4b b8
       180045b41 45 0f 28        MOVAPS     XMM10,xmmword ptr [R11 + local_98[0]]
                 53 a8
       180045b46 45 0f 28        MOVAPS     XMM11,xmmword ptr [R11 + local_a8[0]]
                 5b 98
       180045b4b 49 8b e3        MOV        RSP,R11
       180045b4e 41 5f           POP        leftElementULL
       180045b50 41 5e           POP        downCellIdx
       180045b52 41 5d           POP        cellIndexLL
       180045b54 41 5c           POP        leftIndex2
       180045b56 5f              POP        RDI
       180045b57 5e              POP        RSI
       180045b58 5d              POP        diseaseCountToMove
       180045b59 5b              POP        RBX
       180045b5a c3              RET
