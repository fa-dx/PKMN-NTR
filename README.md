# PKMN-NTR
A Generation VI Pokémon games real-time editing tool for use with NTR CFW.

Discuss this tool here: http://gbatemp.net/threads/wip-pkmn-ntr-pok%C3%A9mon-gen-6-memory-editor.441892/

# Remote controls and bots
In order to use the remote controls or a bot you need to install the InputRedirection CIA: https://github.com/Kazo/InputRedirection, then, after loading NTR CFW open the application to patch the HID moudle and you're ready to go. You don't need to do this step for using the other functions of the software.

## Remote controls:
Press the button to send the command to the game, you can also "touch" the bottom screen, write the coordinates (counted from the top left corner of the screen) and press the "Touch" Button.

## Wonder Trade bot
This script will try Wonder Trade the amount of pokémon in the "# trades" box, starting from the selected box and slot number. Any empty slot will be ignored but still counted towards the total of trades. The information of the Pokémon which will be traded and the received pokémon will appear in the Edit tabs. **You can stop this bot by pressing the "Disconnect" button, restart the application afterwards.**

**Notes:**
- This bot is time-based, so inputs might get lost sometimes.
- If the "Disconnect" button is pressed while the bot is running, the program might crash, this is unharmful, you only need to restart the application and resume.
- The bot will assume that you have unlocked all 31 boxes in the game.
- The following situations will break the bot:
  - The games takes an unusually long time to save or perform the trade animation after the data is received.
  - The bot tries to send an un-tradeable Pokémon (Illegal or Event).
  - The received Pokémon is a Clamperl holding a Deep Sea Scale. (Deap Sea Tooth is handled).
  - You trade a Shelmet or a Karrablast for the other.
- The following features are untested:
  - Handling of the "No trade partner has been found...".
  - Handling of received pokémon that evolves by trading.
- To start the bot make sure the PSS menu is on the bottom screen, the bot will try to press the Wonder Trade button automatically.

# Credits
- **fa-dx**: Gathering offsets, creating the tool.
- **44670**: NTR CFW & NTRClient(this tool is based off a modified NTRClient https://github.com/fa-dx/NTR-Base).
- **Kaphotics**: Helping with a few pieces of code(because I'm a coding noob), PKM Encrypt & Decrypt code + variables from the PKM layout from PKHeX, inspiration (most Pokemon Editing features were inspired by his save editing tool PKHeX).
- **jackmax**: Doing a large-scale rewrite of the code to make it more robust, readable and maintainable.
- **drgoku282**: Remote controls and bot scripting.
- **Stary2001 and Kazo**: For InputRedirection which was the base for the Remote Controls and the Bots.
