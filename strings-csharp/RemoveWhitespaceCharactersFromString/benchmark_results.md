|                             Method |                 source |            Mean |         Error |        StdDev |     Gen0 |     Gen1 |     Gen2 | Allocated |
|----------------------------------- |----------------------- |----------------:|--------------:|--------------:|---------:|---------:|---------:|----------:|
|     RemoveWhiteSpaceWithRegexClass |   Liber(...)mnis. [79] |       965.93 ns |      2.386 ns |      2.115 ns |   0.0801 |        - |        - |     168 B |
|    RemoveWhiteSpaceWithCachedRegex |   Liber(...)mnis. [79] |       910.70 ns |      5.290 ns |      4.417 ns |   0.0801 |        - |        - |     168 B |
| RemoveWhiteSpaceWithSourceGenRegex |   Liber(...)mnis. [79] |       542.55 ns |      5.228 ns |      4.635 ns |   0.0801 |        - |        - |     168 B |
|     RemoveWhiteSpaceWithLinqConcat |   Liber(...)mnis. [79] |     1,026.63 ns |      6.891 ns |      6.446 ns |   0.1221 |        - |        - |     256 B |
|  RemoveWhiteSpaceWithLinqConstruct |   Liber(...)mnis. [79] |       763.27 ns |      9.845 ns |      8.221 ns |   0.4244 |        - |        - |     888 B |
|        RemoveWhiteSpaceWithReplace |   Liber(...)mnis. [79] |       341.28 ns |      4.882 ns |      4.566 ns |   0.0801 |        - |        - |     168 B |
|      RemoveWhiteSpaceWithSplitJoin |   Liber(...)mnis. [79] |       317.65 ns |      5.792 ns |      5.135 ns |   0.3209 |        - |        - |     672 B |
|  RemoveWhiteSpaceWithStringBuilder |   Liber(...)mnis. [79] |       143.32 ns |      2.266 ns |      2.120 ns |   0.1912 |        - |        - |     400 B |
|          RemoveWhiteSpaceWithArray |   Liber(...)mnis. [79] |        88.73 ns |      1.829 ns |      2.314 ns |   0.0802 |        - |        - |     168 B |
|     RemoveWhiteSpaceWithRegexClass |   Liber(...)mnis. [70] |       162.44 ns |      0.596 ns |      0.558 ns |        - |        - |        - |         - |
|    RemoveWhiteSpaceWithCachedRegex |   Liber(...)mnis. [70] |       151.41 ns |      0.537 ns |      0.448 ns |        - |        - |        - |         - |
| RemoveWhiteSpaceWithSourceGenRegex |   Liber(...)mnis. [70] |        89.07 ns |      0.544 ns |      0.482 ns |        - |        - |        - |         - |
|     RemoveWhiteSpaceWithLinqConcat |   Liber(...)mnis. [70] |       793.13 ns |      4.831 ns |      4.519 ns |   0.1221 |        - |        - |     256 B |
|  RemoveWhiteSpaceWithLinqConstruct |   Liber(...)mnis. [70] |       689.81 ns |     11.615 ns |     10.296 ns |   0.4244 |        - |        - |     888 B |
|        RemoveWhiteSpaceWithReplace |   Liber(...)mnis. [70] |       197.15 ns |      0.847 ns |      0.750 ns |        - |        - |        - |         - |
|      RemoveWhiteSpaceWithSplitJoin |   Liber(...)mnis. [70] |        66.25 ns |      1.199 ns |      1.001 ns |   0.0153 |        - |        - |      32 B |
|  RemoveWhiteSpaceWithStringBuilder |   Liber(...)mnis. [70] |       132.74 ns |      1.366 ns |      1.211 ns |   0.1836 |        - |        - |     384 B |
|          RemoveWhiteSpaceWithArray |   Liber(...)mnis. [70] |        83.18 ns |      0.664 ns |      0.518 ns |        - |        - |        - |         - |
|     RemoveWhiteSpaceWithRegexClass |    Qua(...)am. [10333] |   142,570.21 ns |    384.112 ns |    340.505 ns |   8.0566 |        - |        - |   17416 B |
|    RemoveWhiteSpaceWithCachedRegex |    Qua(...)am. [10333] |   171,150.49 ns |    518.937 ns |    485.414 ns |   8.0566 |        - |        - |   17416 B |
| RemoveWhiteSpaceWithSourceGenRegex |    Qua(...)am. [10333] |    80,745.95 ns |    170.170 ns |    150.851 ns |   8.1787 |        - |        - |   17416 B |
|     RemoveWhiteSpaceWithLinqConcat |    Qua(...)am. [10333] |   111,991.73 ns |    867.176 ns |    811.157 ns |   8.3008 |        - |        - |   17504 B |
|  RemoveWhiteSpaceWithLinqConstruct |    Qua(...)am. [10333] |    81,583.89 ns |    275.912 ns |    230.399 ns |  32.4707 |        - |        - |   68312 B |
|        RemoveWhiteSpaceWithReplace |    Qua(...)am. [10333] |    35,890.03 ns |    462.477 ns |    432.602 ns |  45.8374 |        - |        - |   96424 B |
|      RemoveWhiteSpaceWithSplitJoin |    Qua(...)am. [10333] |    55,363.64 ns |  1,095.223 ns |  1,217.338 ns |  46.5088 |        - |        - |   97280 B |
|  RemoveWhiteSpaceWithStringBuilder |    Qua(...)am. [10333] |    22,176.37 ns |    338.913 ns |    428.616 ns |  18.1580 |        - |        - |   38160 B |
|          RemoveWhiteSpaceWithArray |    Qua(...)am. [10333] |    13,160.96 ns |     73.274 ns |     57.207 ns |   8.2550 |        - |        - |   17416 B |
|     RemoveWhiteSpaceWithRegexClass |   Quas(...)uam. [8697] |    10,383.23 ns |     45.645 ns |     38.116 ns |        - |        - |        - |         - |
|    RemoveWhiteSpaceWithCachedRegex |   Quas(...)uam. [8697] |    10,363.67 ns |     32.121 ns |     26.823 ns |        - |        - |        - |         - |
| RemoveWhiteSpaceWithSourceGenRegex |   Quas(...)uam. [8697] |     4,574.65 ns |      8.893 ns |      7.426 ns |        - |        - |        - |         - |
|     RemoveWhiteSpaceWithLinqConcat |   Quas(...)uam. [8697] |    93,505.06 ns |  1,402.391 ns |  1,311.797 ns |   8.3008 |        - |        - |   17504 B |
|  RemoveWhiteSpaceWithLinqConstruct |   Quas(...)uam. [8697] |    57,992.10 ns |    423.700 ns |    396.329 ns |  32.4707 |        - |        - |   68312 B |
|        RemoveWhiteSpaceWithReplace |   Quas(...)uam. [8697] |     5,482.86 ns |     12.324 ns |     10.925 ns |        - |        - |        - |         - |
|      RemoveWhiteSpaceWithSplitJoin |   Quas(...)uam. [8697] |     4,547.31 ns |     22.163 ns |     20.731 ns |   0.0153 |        - |        - |      32 B |
|  RemoveWhiteSpaceWithStringBuilder |   Quas(...)uam. [8697] |    13,983.78 ns |    235.857 ns |    209.081 ns |  16.5253 |        - |        - |   34888 B |
|          RemoveWhiteSpaceWithArray |   Quas(...)uam. [8697] |     8,331.07 ns |    118.704 ns |    111.035 ns |        - |        - |        - |         - |
|     RemoveWhiteSpaceWithRegexClass | The(...).\r\n [134416] | 2,359,749.18 ns | 16,289.664 ns | 15,237.362 ns |  58.5938 |  58.5938 |  58.5938 |  215722 B |
|    RemoveWhiteSpaceWithCachedRegex | The(...).\r\n [134416] | 2,394,623.65 ns | 13,486.855 ns | 12,615.612 ns |  58.5938 |  58.5938 |  58.5938 |  215722 B |
| RemoveWhiteSpaceWithSourceGenRegex | The(...).\r\n [134416] | 1,600,989.73 ns | 11,529.404 ns | 10,784.612 ns |  60.5469 |  60.5469 |  60.5469 |  215721 B |
|     RemoveWhiteSpaceWithLinqConcat | The(...).\r\n [134416] | 1,644,222.18 ns |  9,390.608 ns |  8,324.530 ns |  66.4063 |  66.4063 |  66.4063 |  215791 B |
|  RemoveWhiteSpaceWithLinqConstruct | The(...).\r\n [134416] | 1,196,309.16 ns |  4,992.237 ns |  4,168.744 ns | 175.7813 | 175.7813 | 175.7813 |  694340 B |
|        RemoveWhiteSpaceWithReplace | The(...).\r\n [134416] |   670,950.16 ns |  4,686.095 ns |  4,383.376 ns | 230.4688 | 230.4688 | 230.4688 |  739100 B |
|      RemoveWhiteSpaceWithSplitJoin | The(...).\r\n [134416] | 1,608,495.81 ns | 12,348.998 ns | 10,947.065 ns | 248.0469 | 185.5469 | 185.5469 | 1400751 B |
|  RemoveWhiteSpaceWithStringBuilder | The(...).\r\n [134416] |   395,249.70 ns |  5,044.383 ns |  4,718.519 ns | 142.5781 | 142.5781 | 142.5781 |  484632 B |
|          RemoveWhiteSpaceWithArray | The(...).\r\n [134416] |   387,348.57 ns |  1,525.755 ns |  1,352.542 ns |  66.4063 |  66.4063 |  66.4063 |  215703 B |


|                            Method |                       source |          Mean |      Error |     StdDev |   Gen0 | Allocated |
|---------------------------------- |----------------------------- |--------------:|-----------:|-----------:|-------:|----------:|
|     TrimWhitespaceUsingStringTrim |    \t\t\t\t\t(...)      [98] |     46.230 ns |  0.9589 ns |  0.8500 ns | 0.0688 |     144 B |
| TrimWhitespaceUsingSourceGenRegex |    \t\t\t\t\t(...)      [98] |    394.669 ns |  1.3316 ns |  1.1805 ns | 0.0687 |     144 B |
|     TrimWhitespaceUsingStringTrim | \n\n\n\n(...)\t\t\t\t [4567] |    403.851 ns |  1.5766 ns |  1.3976 ns | 4.3287 |    9080 B |
| TrimWhitespaceUsingSourceGenRegex | \n\n\n\n(...)\t\t\t\t [4567] | 15,356.036 ns | 52.2038 ns | 40.7573 ns | 4.3030 |    9080 B |
|     TrimWhitespaceUsingStringTrim |         In i(...)tus. [4527] |      3.180 ns |  0.0061 ns |  0.0057 ns |      - |         - |
| TrimWhitespaceUsingSourceGenRegex |         In i(...)tus. [4527] | 14,463.895 ns | 36.6683 ns | 30.6197 ns |      - |         - |
|     TrimWhitespaceUsingStringTrim |         Omnis(...)orro. [58] |      3.170 ns |  0.0022 ns |  0.0021 ns |      - |         - |
| TrimWhitespaceUsingSourceGenRegex |         Omnis(...)orro. [58] |    188.157 ns |  0.8899 ns |  0.7889 ns |      - |         - |

