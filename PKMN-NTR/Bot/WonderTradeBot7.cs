using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ntrbase.Bot
{
    class WonderTradeBot7
    {
        private enum botstates { startbot, initializeFC1, initializeFC2, readpoke, writelastbox, presstradebutton, testtrademenu, pressWTbutton, testWTscreen, pressWTstart, testboxes, touchpoke, canceltouch, testpoke, starttrade, confirmtrade, testboxesout, waitfortrade, testtradefinish, tryfinish, finishtrade, collectFC1, collectFC2, collectFC3, collectFC4, collectFC5, exitbot };

        // Bot variables
        public int botresult;
        public bool botstop;

        // Class variables
        private int botstate;
        private int attempts;
        private int maxreconnect;
        private bool boxchange;
        private bool notradepartner;
        private bool tradeevo;
        private bool taskresultbool;
        private bool iscomerror;
        private uint currentPID;
        private uint currentTotalFC;
        private uint currentFC;
        private uint nextFC;
        private Timer tradeTimer;
        Task<bool> waitTaskbool;
        Task<long> waitTaskint;

        // Input variables
        private int currentbox;
        private int currentslot;
        private int quantity;
        private bool collectFC;

        // Class constants
        private readonly int commandtime = 250;
        private readonly int delaytime = 400;

        // Data offsets
        private uint totalFCoff = 0x33124D5C;
        private uint currentFCoff = 0x33124D58;
        private uint trademenuOff = 0x6749D4; // 1.0: 0x672790;
        private uint trademenuIN = 0xC2D00000; // 1.0 :0x41200000;
        private uint trademenuOUT = 0xC2C00000; // 1.0: 0x41B80000;
        private uint tradeready = 0x3F800000;
        private uint wtscreenOff = 0x6703E8; // 1.0: 0x10F1D0;
        private uint wtscreenIN = 0x00; // 1.0: 0x520000;
        //private uint wtscreenOUT = 0x01; // 1.0 0x720000;
        private uint boxesOff = 0x674820; //1.0: 0x10F1A0;
        private uint boxesIN = 0x42210000; // 1.0: 0x6F0000;
        private uint boxesOUT = 0x42220000; // 1.0: 0x520000;
        //private uint boxesviewOff = 0x672D04;
        //private uint boxesviewIN = 0x00000000;
        //private uint boxesviewOUT = 0x41000000;
        private uint dialogOff = 0x6747D8; // 1.0: 0x63DD68;
        private uint dialogIn = 0x00000000; // 1.0: 0x0C;
        private uint dialogOut = 0x41B80000; // 1.0: 0x0B;
        private uint toppkmOff = 0x30000298;
        private uint currentboxOff = 0x330D982F;

        #region FCtable
        public static readonly uint[] FCtable = { 6, 16, 31, 61, 101, 151, 211, 281, 361, 451, 551, 651, 751, 851, 951, 1051, 1151, 1251, 1351, 1451, 1571, 1691, 1811, 1931, 2051, 2171, 2291, 2411, 2531, 2651, 2801, 2951, 3101, 3251, 3401, 3551, 3701, 3851, 4001, 4151, 4331, 4511, 4691, 4871, 5051, 5231, 5411, 5591, 5771, 5951, 6161, 6371, 6581, 6791, 7001, 7211, 7421, 7631, 7841, 8051, 8291, 8531, 8771, 9011, 9251, 9491, 9731, 9971, 10211, 10451, 10721, 10991, 11261, 11531, 11801, 12071, 12341, 12611, 12881, 13151, 13421, 13691, 13961, 14231, 14501, 14771, 15041, 15311, 15581, 15851, 16121, 16391, 16661, 16931, 17201, 17471, 17741, 18011, 18281, 18551, 18851, 19151, 19451, 19751, 20051, 20351, 20651, 20951, 21251, 21551, 21851, 22151, 22451, 22751, 23051, 23351, 23651, 23951, 24251, 24551, 24851, 25151, 25451, 25751, 26051, 26351, 26651, 26951, 27251, 27551, 27851, 28151, 28451, 28751, 29051, 29351, 29651, 29951, 30251, 30551, 30851, 31151, 31451, 31751, 32051, 32351, 32651, 32951, 33251, 33551, 33851, 34151, 34451, 34751, 35051, 35351, 35651, 35951, 36251, 36551, 36851, 37151, 37451, 37751, 38051, 38351, 38651, 38951, 39251, 39551, 39851, 40151, 40451, 40751, 41051, 41351, 41651, 41951, 42251, 42551, 42851, 43151, 43451, 43751, 44051, 44351, 44651, 44951, 45251, 45551, 45851, 46151, 46451, 46751, 47051, 47351, 47651, 47951, 48251, 48551, 48851, 49151, 49451, 49751, 50051, 50351, 50651, 50951, 51251, 51551, 51851, 52151, 52451, 52751, 53051, 53351, 53651, 53951, 54251, 54551, 54851, 55151, 55451, 55751, 56051, 56351, 56651, 56951, 57251, 57551, 57851, 58151, 58451, 58751, 59051, 59351, 59651, 59951, 60251, 60551, 60851, 61151, 61451, 61751, 62051, 62351, 62651, 62951, 63251, 63551, 63851, 64151, 64451, 64751, 65051, 65351, 65651, 65951, 66251, 66551, 66851, 67151, 67451, 67751, 68051, 68351, 68651, 68951, 69251, 69551, 69851, 70151, 70451, 70751, 71051, 71351, 71651, 71951, 72251, 72551, 72851, 73151, 73451, 73751, 74051, 74351, 74651, 74951, 75251, 75551, 75851, 76151, 76451, 76751, 77051, 77351, 77651, 77951, 78251, 78551, 78851, 79151, 79451, 79751, 80051, 80351, 80651, 80951, 81251, 81551, 81851, 82151, 82451, 82751, 83051, 83351, 83651, 83951, 84251, 84551, 84851, 85151, 85451, 85751, 86051, 86351, 86651, 86951, 87251, 87551, 87851, 88151, 88451, 88751, 89051, 89351, 89651, 89951, 90251, 90551, 90851, 91151, 91451, 91751, 92051, 92351, 92651, 92951, 93251, 93551, 93851, 94151, 94451, 94751, 95051, 95351, 95651, 95951, 96251, 96551, 96851, 97151, 97451, 97751, 98051, 98351, 98651, 98951, 99251, 99551, 99851, 100151, 100451, 100751, 101051, 101351, 101651, 101951, 102251, 102551, 102851, 103151, 103451, 103751, 104051, 104351, 104651, 104951, 105251, 105551, 105851, 106151, 106451, 106751, 107051, 107351, 107651, 107951, 108251, 108551, 108851, 109151, 109451, 109751, 110051, 110351, 110651, 110951, 111251, 111551, 111851, 112151, 112451, 112751, 113051, 113351, 113651, 113951, 114251, 114551, 114851, 115151, 115451, 115751, 116051, 116351, 116651, 116951, 117251, 117551, 117851, 118151, 118451, 118751, 119051, 119351, 119651, 119951, 120251, 120551, 120851, 121151, 121451, 121751, 122051, 122351, 122651, 122951, 123251, 123551, 123851, 124151, 124451, 124751, 125051, 125351, 125651, 125951, 126251, 126551, 126851, 127151, 127451, 127751, 128051, 128351, 128651, 128951, 129251, 129551, 129851, 130151, 130451, 130751, 131051, 131351, 131651, 131951, 132251, 132551, 132851, 133151, 133451, 133751, 134051, 134351, 134651, 134951, 135251, 135551, 135851, 136151, 136451, 136751, 137051, 137351, 137651, 137951, 138251, 138551, 138851, 139151, 139451, 139751, 140051, 140351, 140651, 140951, 141251, 141551, 141851, 142151, 142451, 142751, 143051, 143351, 143651, 143951, 144251, 144551, 144851, 145151, 145451, 145751, 146051, 146351, 146651, 146951, 147251, 147551, 147851, 148151, 148451, 148751, 149051, 149351, 149651, 149951, 150251, 150551, 150851, 151151, 151451, 151751, 152051, 152351, 152651, 152951, 153251, 153551, 153851, 154151, 154451, 154751, 155051, 155351, 155651, 155951, 156251, 156551, 156851, 157151, 157451, 157751, 158051, 158351, 158651, 158951, 159251, 159551, 159851, 160151, 160451, 160751, 161051, 161351, 161651, 161951, 162251, 162551, 162851, 163151, 163451, 163751, 164051, 164351, 164651, 164951, 165251, 165551, 165851, 166151, 166451, 166751, 167051, 167351, 167651, 167951, 168251, 168551, 168851, 169151, 169451, 169751, 170051, 170351, 170651, 170951, 171251, 171551, 171851, 172151, 172451, 172751, 173051, 173351, 173651, 173951, 174251, 174551, 174851, 175151, 175451, 175751, 176051, 176351, 176651, 176951, 177251, 177551, 177851, 178151, 178451, 178751, 179051, 179351, 179651, 179951, 180251, 180551, 180851, 181151, 181451, 181751, 182051, 182351, 182651, 182951, 183251, 183551, 183851, 184151, 184451, 184751, 185051, 185351, 185651, 185951, 186251, 186551, 186851, 187151, 187451, 187751, 188051, 188351, 188651, 188951, 189251, 189551, 189851, 190151, 190451, 190751, 191051, 191351, 191651, 191951, 192251, 192551, 192851, 193151, 193451, 193751, 194051, 194351, 194651, 194951, 195251, 195551, 195851, 196151, 196451, 196751, 197051, 197351, 197651, 197951, 198251, 198551, 198851, 199151, 199451, 199751, 200051, 200351, 200651, 200951, 201251, 201551, 201851, 202151, 202451, 202751, 203051, 203351, 203651, 203951, 204251, 204551, 204851, 205151, 205451, 205751, 206051, 206351, 206651, 206951, 207251, 207551, 207851, 208151, 208451, 208751, 209051, 209351, 209651, 209951, 210251, 210551, 210851, 211151, 211451, 211751, 212051, 212351, 212651, 212951, 213251, 213551, 213851, 214151, 214451, 214751, 215051, 215351, 215651, 215951, 216251, 216551, 216851, 217151, 217451, 217751, 218051, 218351, 218651, 218951, 219251, 219551, 219851, 220151, 220451, 220751, 221051, 221351, 221651, 221951, 222251, 222551, 222851, 223151, 223451, 223751, 224051, 224351, 224651, 224951, 225251, 225551, 225851, 226151, 226451, 226751, 227051, 227351, 227651, 227951, 228251, 228551, 228851, 229151, 229451, 229751, 230051, 230351, 230651, 230951, 231251, 231551, 231851, 232151, 232451, 232751, 233051, 233351, 233651, 233951, 234251, 234551, 234851, 235151, 235451, 235751, 236051, 236351, 236651, 236951, 237251, 237551, 237851, 238151, 238451, 238751, 239051, 239351, 239651, 239951, 240251, 240551, 240851, 241151, 241451, 241751, 242051, 242351, 242651, 242951, 243251, 243551, 243851, 244151, 244451, 244751, 245051, 245351, 245651, 245951, 246251, 246551, 246851, 247151, 247451, 247751, 248051, 248351, 248651, 248951, 249251, 249551, 249851, 250151, 250451, 250751, 251051, 251351, 251651, 251951, 252251, 252551, 252851, 253151, 253451, 253751, 254051, 254351, 254651, 254951, 255251, 255551, 255851, 256151, 256451, 256751, 257051, 257351, 257651, 257951, 258251, 258551, 258851, 259151, 259451, 259751, 260051, 260351, 260651, 260951, 261251, 261551, 261851, 262151, 262451, 262751, 263051, 263351, 263651, 263951, 264251, 264551, 264851, 265151, 265451, 265751, 266051, 266351, 266651, 266951, 267251, 267551, 267851, 268151, 268451, 268751, 269051, 269351, 269651, 269951, 270251, 270551, 270851, 271151, 271451, 271751, 272051, 272351, 272651, 272951, 273251, 273551, 273851, 274151, 274451, 274751, 275051, 275351, 275651, 275951, 276251, 276551, 276851, 277151, 277451, 277751, 278051, 278351, 278651, 278951, 279251, 279551, 279851, 280151, 280451, 280751, 281051, 281351, 281651, 281951, 282251, 282551, 282851, 283151, 283451, 283751, 284051, 284351, 284651, 284951, 285251, 285551, 285851, 286151, 286451, 286751, 287051, 287351, 287651, 287951, 288251 };
        #endregion FCtable

        public WonderTradeBot7(int StartBox, int StartSlot, int Amount, bool FCaftertrade)
        {
            botresult = 0;
            botstop = false;

            botstate = (int)botstates.startbot;
            attempts = 0;
            maxreconnect = 10;
            boxchange = true;
            notradepartner = false;
            tradeevo = false;
            taskresultbool = false;
            iscomerror = false;
            currentPID = 0;
            currentTotalFC = 0;
            currentFC = 0;
            nextFC = 0;
            tradeTimer = new Timer();
            tradeTimer.Interval = 100000; // Trade timeout, 100 s
            tradeTimer.Tick += tradeTimer_Tick;

            currentbox = StartBox - 1;
            currentslot = StartSlot - 1;
            quantity = Amount;
            collectFC = FCaftertrade;
        }

        public async Task<int> RunBot()
        {
            try
            {
                while (!botstop)
                {
                    switch (botstate)
                    {
                        case (int)botstates.startbot:
                            Report("Bot: START Gen 7 Wonder Trade bot");
                            if (collectFC)
                                botstate = (int)botstates.initializeFC1;
                            else
                                botstate = (int)botstates.readpoke;
                            break;

                        case (int)botstates.initializeFC1:
                            waitTaskbool = Program.helper.waitNTRread(totalFCoff);
                            if (await waitTaskbool)
                            {
                                attempts = 0;
                                currentTotalFC = Program.helper.lastRead;
                                Report("Bot: Current Total FC: " + currentTotalFC);
                                botstate = (int)botstates.initializeFC2;
                            }
                            else
                            {
                                attempts++;
                                botresult = 2;
                                botstate = (int)botstates.initializeFC1;
                            }
                            break;

                        case (int)botstates.initializeFC2:
                            waitTaskbool = Program.helper.waitNTRread(currentFCoff);
                            if (await waitTaskbool)
                            {
                                attempts = 0;
                                currentFC = Program.helper.lastRead;
                                Report("Bot: Current FC: " + currentFC);
                                Program.gCmdWindow.updateFCfields(currentTotalFC, currentFC);
                                int i = 0;
                                while (currentTotalFC >= nextFC)
                                {
                                    nextFC = FCtable[i];
                                    i++;
                                }
                                Report("Bot: Points for next level: " + (nextFC - currentTotalFC));
                                botstate = (int)botstates.readpoke;
                            }
                            else
                            {
                                attempts++;
                                botresult = 2;
                                botstate = (int)botstates.initializeFC2;
                            }
                            break;

                        case (int)botstates.readpoke:
                            Report("Bot: Look for pokemon to trade");
                            waitTaskint = Program.helper.waitPokeRead(currentbox, currentslot);
                            long dataready = await waitTaskint;
                            switch (dataready)
                            {
                                case -2:
                                    botresult = 2;
                                    Report("Bot: Error detected");
                                    attempts = 11;
                                    break;
                                case -1:
                                    Report("Bot: Slot is empty");
                                    getNextSlot();
                                    if (quantity > 0) // Test if there are more trades
                                        botstate = (int)botstates.readpoke;
                                    else
                                    { // Stop if no more trades
                                        botresult = 0;
                                        botstate = (int)botstates.exitbot;
                                    }
                                    break;
                                default:
                                    {
                                        currentPID = Convert.ToUInt32(dataready);
                                        Report("Bot: Pokemon found");
                                        botstate = (int)botstates.writelastbox;
                                    }
                                    break;
                            }
                            break;

                        case (int)botstates.writelastbox:
                            if (boxchange)
                            {
                                Report("Bot: Set current box");
                                waitTaskbool = Program.helper.waitNTRwrite(currentboxOff, Convert.ToUInt32(currentbox), Program.gCmdWindow.pid);
                                if (await waitTaskbool)
                                {
                                    attempts = 0;
                                    boxchange = false;
                                    botstate = (int)botstates.presstradebutton;
                                }
                                else
                                {
                                    attempts++;
                                    botresult = 1;
                                    botstate = (int)botstates.writelastbox;
                                }
                            }
                            else
                            {
                                botstate = (int)botstates.presstradebutton;
                            }
                            break;

                        case (int)botstates.presstradebutton:
                            Report("Bot: Press Trade Button");
                            await Task.Delay(delaytime);
                            waitTaskbool = Program.helper.waittouch(200, 120);
                            if (await waitTaskbool)
                                botstate = (int)botstates.testtrademenu;
                            else
                            {
                                attempts++;
                                botresult = 6;
                                botstate = (int)botstates.presstradebutton;
                            }
                            break;

                        case (int)botstates.testtrademenu:
                            Report("Bot: Test if the trademenu is shown");
                            waitTaskbool = Program.helper.timememoryinrange(trademenuOff, trademenuIN, 0x100000, 100, 5000);
                            taskresultbool = await waitTaskbool;
                            if (taskresultbool)
                            {
                                attempts = 0;
                                botstate = (int)botstates.pressWTbutton;
                            }
                            else
                            {
                                attempts++;
                                botresult = 2;
                                botstate = (int)botstates.presstradebutton;
                            }
                            break;

                        case (int)botstates.pressWTbutton:
                            Report("Bot: Press Wonder Trade");
                            await Task.Delay(delaytime);
                            waitTaskbool = Program.helper.waittouch(160, 160);
                            if (await waitTaskbool)
                                botstate = (int)botstates.testWTscreen;
                            else
                            {
                                attempts++;
                                botresult = 6;
                                botstate = (int)botstates.pressWTbutton;
                            }
                            break;

                        case (int)botstates.testWTscreen:
                            Report("Bot: Test if the Wonder Trade screen is shown");
                            waitTaskbool = Program.helper.timememoryinrange(wtscreenOff, wtscreenIN, 0x01, 100, 5000);
                            taskresultbool = await waitTaskbool;
                            if (taskresultbool)
                            {
                                attempts = 0;
                                botstate = (int)botstates.pressWTstart;
                            }
                            else
                            {
                                attempts++;
                                botresult = 2;
                                botstate = (int)botstates.pressWTbutton;
                            }
                            break;

                        case (int)botstates.pressWTstart:
                            Report("Bot: Press Start");
                            await Task.Delay(1500);
                            Program.helper.quickbuton(LookupTable.keyA, commandtime);
                            await Task.Delay(commandtime + delaytime);
                            botstate = (int)botstates.testboxes;
                            break;

                        case (int)botstates.testboxes:
                            Report("Bot: Test if the boxes are shown");
                            waitTaskbool = Program.helper.timememoryinrange(boxesOff, boxesIN, 0x10000, 100, 5000);
                            taskresultbool = await waitTaskbool;
                            if (taskresultbool)
                            {
                                attempts = 0;
                                botstate = (int)botstates.touchpoke;
                            }
                            else
                            {
                                attempts++;
                                botresult = 2;
                                botstate = (int)botstates.pressWTstart;
                            }
                            break;

                        case (int)botstates.touchpoke:
                            Report("Bot: Touch pokémon");
                            await Task.Delay(2000);
                            waitTaskbool = Program.helper.waittouch(LookupTable.pokeposX7[currentslot], LookupTable.pokeposY7[currentslot]);
                            if (await waitTaskbool)
                            {
                                botstate = (int)botstates.testpoke;
                            }
                            else
                            {
                                attempts++;
                                botresult = 6;
                                botstate = (int)botstates.touchpoke;
                            }
                            break;

                        case (int)botstates.testpoke:
                            Report("Bot: Test if pokemon is selected");
                            waitTaskint = Program.helper.waitPokeRead(toppkmOff);
                            long dataready2 = await waitTaskint;
                            switch (dataready2)
                            {
                                case -2:
                                case -1:
                                    botresult = 2;
                                    Report("Bot: Error detected or slot is empty");
                                    attempts = 11;
                                    break;
                                default:
                                    {
                                        if (Convert.ToUInt32(dataready2) == currentPID)
                                        {
                                            attempts = 0;
                                            botstate = (int)botstates.starttrade;
                                        }
                                        else
                                        {
                                            attempts++;
                                            botresult = -1;
                                            botstate = (int)botstates.canceltouch;
                                        }
                                    }
                                    break;
                            }
                            break;

                        case (int)botstates.canceltouch:
                            Report("Bot: Cancel selection and check again");
                            waitTaskint = Program.helper.waitPokeRead(currentbox, currentslot);
                            long dataready3 = await waitTaskint;
                            if (dataready3 > 0)
                            {
                                currentPID = Convert.ToUInt32(dataready3);
                            }
                            waitTaskbool = Program.helper.waitbutton(LookupTable.keyB);
                            if (await waitTaskbool)
                            {
                                botstate = (int)botstates.touchpoke;
                            }
                            else
                            {
                                attempts++;
                                botresult = 7;
                                botstate = (int)botstates.touchpoke;
                            }
                            break;

                        case (int)botstates.starttrade:
                            Report("Bot: Press Start");
                            waitTaskbool = Program.helper.waitbutton(LookupTable.keyA);
                            if (await waitTaskbool)
                                botstate = (int)botstates.confirmtrade;
                            else
                            {
                                attempts++;
                                botresult = 7;
                                botstate = (int)botstates.starttrade;
                            }
                            break;

                        case (int)botstates.confirmtrade:
                            Report("Bot: Press Yes");
                            waitTaskbool = Program.helper.waitbutton(LookupTable.keyA);
                            if (await waitTaskbool)
                                botstate = (int)botstates.testboxesout;
                            else
                            {
                                attempts++;
                                botresult = 7;
                                botstate = (int)botstates.confirmtrade;
                            }
                            break;

                        case (int)botstates.testboxesout:
                            Report("Bot: Test if the boxes are not shown");
                            waitTaskbool = Program.helper.timememoryinrange(boxesOff, boxesOUT, 0x10000, 100, 5000);
                            taskresultbool = await waitTaskbool;
                            if (taskresultbool)
                            {
                                attempts = -40; // Try 50 button presses
                                botstate = (int)botstates.waitfortrade;
                                tradeTimer.Start();
                            }
                            else
                            {
                                attempts++;
                                botresult = 2;
                                botstate = (int)botstates.touchpoke;
                            }
                            break;

                        case (int)botstates.waitfortrade:
                            Report("Bot: Wait for trade");
                            waitTaskbool = Program.helper.memoryinrange(trademenuOff, tradeready, 0x10000);
                            taskresultbool = await waitTaskbool;
                            if (taskresultbool)
                            {
                                tradeTimer.Stop();
                                Report("Bot: Trade detected");
                                await Program.helper.waitPokeRead(currentbox, currentslot);
                                Report("Bot: Wait 30 seconds");
                                await Task.Delay(30000);
                                botstate = (int)botstates.testtradefinish;
                            }
                            else if (notradepartner)
                            { // Timeout
                                boxchange = true; // Might fix a couple of errors
                                botstate = (int)botstates.testtradefinish;
                            }
                            else
                            {
                                await Task.Delay(2000);
                            }
                            break;

                        case (int)botstates.testtradefinish:
                            Report("Bot: Test if the trade is finished");
                            waitTaskbool = Program.helper.memoryinrange(trademenuOff, trademenuOUT, 0x1000000);
                            taskresultbool = await waitTaskbool;
                            if (taskresultbool)
                            {
                                attempts = 0;
                                iscomerror = false;
                                if (collectFC && !notradepartner)
                                    botstate = (int)botstates.collectFC1;
                                else
                                    botstate = (int)botstates.finishtrade;
                            }
                            else
                            {
                                attempts++;
                                botresult = -1;
                                botstate = (int)botstates.tryfinish;
                                if (Program.helper.lastRead == 0x00000000)
                                { // Communication error, will try again
                                    if (iscomerror)
                                    {
                                        Report("Bot: Communication error detected");
                                        botresult = 4;
                                        attempts = 11;
                                    }
                                    else
                                    {
                                        Report("Bot: Communication error? Test again");
                                        iscomerror = true;
                                    }
                                }
                                if (Program.helper.lastRead == 0xBF800000)
                                {
                                    iscomerror = false;
                                    tradeevo = true;
                                }
                                else
                                {
                                    iscomerror = false;
                                }
                            }
                            break;

                        case (int)botstates.tryfinish:
                            if (!tradeevo)
                            {
                                Report("Bot: Press B button");
                                waitTaskbool = Program.helper.waitbutton(LookupTable.keyB);
                            }
                            else
                            {
                                Report("Bot: Trade evolution detected, press A button");
                                waitTaskbool = Program.helper.waitbutton(LookupTable.keyA);
                            }
                            if (await waitTaskbool)
                                botstate = (int)botstates.testtradefinish;
                            else
                            {
                                attempts++;
                                botresult = 7;
                                botstate = (int)botstates.testtradefinish;
                            }
                            break;

                        case (int)botstates.finishtrade:
                            if (!notradepartner)
                                getNextSlot();
                            notradepartner = false;
                            tradeevo = false;
                            if (quantity > 0) // Test if there are more trades
                            {
                                botstate = (int)botstates.readpoke;
                                attempts = 0;
                                tradeTimer.Stop();
                            }
                            else
                            { // Stop if no more trades
                                botresult = 0;
                                botstate = (int)botstates.exitbot;
                            }
                            break;

                        case (int)botstates.collectFC1:
                            Report("Bot: Trigger Dialog");
                            await Task.Delay(1000);
                            waitTaskbool = Program.helper.waitbutton(LookupTable.keyA);
                            if (await waitTaskbool)
                                botstate = (int)botstates.collectFC2;
                            else
                            {
                                attempts++;
                                botresult = 7;
                                botstate = (int)botstates.testtradefinish;
                            }
                            break;

                        case (int)botstates.collectFC2:
                            Report("Bot: Test if dialog has started");
                            waitTaskbool = Program.helper.memoryinrange(dialogOff, dialogIn, 0x010000);
                            if (await waitTaskbool)
                            {
                                attempts = 0;
                                botstate = (int)botstates.collectFC3;
                            }
                            else
                            {
                                attempts++;
                                botresult = 2;
                                botstate = (int)botstates.collectFC1;
                            }
                            break;

                        case (int)botstates.collectFC3:
                            Report("Bot: Continue dialog");
                            waitTaskbool = Program.helper.waitbutton(LookupTable.keyB);
                            if (await waitTaskbool)
                                botstate = (int)botstates.collectFC4;
                            else
                            {
                                attempts++;
                                botresult = 7;
                                botstate = (int)botstates.collectFC3;
                            }
                            break;

                        case (int)botstates.collectFC4:
                            Report("Bot: Test if dialog has finished");
                            waitTaskbool = Program.helper.memoryinrange(dialogOff, dialogOut, 0x010000);
                            if (await waitTaskbool || Program.helper.lastRead == 0x0D)
                            {
                                attempts = 0;
                                botstate = (int)botstates.collectFC5;
                            }
                            else
                            {
                                attempts++;
                                botresult = 2;
                                botstate = (int)botstates.collectFC3;
                            }
                            break;

                        case (int)botstates.collectFC5:
                            Report("Bot: Test FC");
                            waitTaskbool = Program.helper.waitNTRread(totalFCoff);
                            if (await waitTaskbool)
                            {
                                attempts = 0;
                                currentTotalFC = Program.helper.lastRead;
                                Report("Bot: Current Total FC: " + currentTotalFC);
                                if (currentTotalFC >= nextFC)
                                {
                                    Report("Bot: Festival Plaza level up");
                                    getNextSlot();
                                    botresult = 3;
                                    botstate = (int)botstates.exitbot;
                                }
                                else
                                    botstate = (int)botstates.finishtrade;
                            }
                            else
                            {
                                attempts++;
                                botresult = 2;
                                botstate = (int)botstates.collectFC5;
                            }
                            break;

                        case (int)botstates.exitbot:
                            Report("Bot: Stop Gen 7 Wonder Trade bot");
                            botstop = true;
                            break;

                        default:
                            Report("Bot: Stop Gen 7 Wonder Trade bot");
                            botresult = -1;
                            botstop = true;
                            break;
                    }
                    if (attempts > 10)
                    { // Too many attempts
                        if (maxreconnect > 0)
                        {
                            Report("Bot: Try reconnection to fix error");
                            waitTaskbool = Program.gCmdWindow.Reconnect();
                            maxreconnect--;
                            if (await waitTaskbool)
                            {
                                await Task.Delay(5000);
                                attempts = 0;
                            }
                            else
                            {
                                botresult = -1;
                                botstop = true;
                            }
                        }
                        else
                        {
                            Report("Bot: Stop Gen 7 Wonder Trade bot");
                            botstop = true;
                        }
                    }
                }
                tradeTimer.Stop();
                return botresult;
            }
            catch (Exception ex)
            {
                tradeTimer.Stop();
                Report("Bot: Exception detected:");
                Report(ex.Source);
                Report(ex.Message);
                Report(ex.StackTrace);
                Report("Bot: STOP Gen 7 Wonder Trade bot");
                MessageBox.Show(ex.Message);
                return -1;
            }
        }

        private void Report(string log)
        {
            Program.gCmdWindow.addtoLog(log);
        }

        private void getNextSlot()
        {
            currentslot++;
            if (currentslot >= 30)
            {
                currentbox++;
                currentslot = 0;
                boxchange = true;
                if (currentbox >= 32)
                    currentbox = 0;
            }
            quantity--;
            Program.gCmdWindow.updateWTslots(currentbox, currentslot, quantity);
        }

        private void tradeTimer_Tick(object sender, EventArgs e)
        {
            tradeTimer.Stop();
            Report("Bot: Trade timed out");
            attempts = -40;
            notradepartner = true;
        }
    }
}
