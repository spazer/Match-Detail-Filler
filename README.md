# Match-Detail-Filler
This program helps generate match details for smash games on Liquipedia.

Generating match details for an otherwise completed bracket can take forever. This program is intended to be used when a playlist is available (on youtube, vods.co, etc.), allowing you to quickly add details. The main benefits are autocomplete (no more copy/pasting Pokémon Stadium!), not having to copy paste bits of templates from the wiki, and the ability to move around the various entry fields with little effort.

Put the match and round number in **Round** (eg. *r1m1*).

Paste the youtube link in **VOD Link**. Hit **Trim URL** to remove playlists and other crud that may be affixed to the URL. Timestamps should be left alone.

The **Player 1** and **Player 2** fields are for player names/gamertags. Sometimes, the order in which players appear on Liquipedia do not match their positions in the VOD. These text fields are here so that you can remember which column is for which player. This is especially useful in doubles. THESE FIELDS ARE IGNORED WHEN GENERATING MATCH INFO.

The columns beneath each player are for characters. Autocomplete is enabled here. Typing a character into row 1 will auto-populate the rest of the column. Keep this in mind if character switches happen.

The **Stage** column is for stages. Autocomplete is enabled here. Stages will be auto-capitalized when you leave the textbox. At the end, **rows without a stage will be ignored**.

**P1 stocks** and **P2 stocks** indicate how many stocks each player has left per game. The win parameter will be automatically filled using this info. Only game wins are supported, NOT set wins.

When you're all done, hit **Fill**. Copy/paste the resulting text into the appropriate place in your Liquipedia bracket. 

**Use tab to move around the textboxes**. It helps a ton.

When you're done pasting the details into Liquipedia, click **Clear** to erase everything in the textboxes.

Doubles works the same way as Singles, but with more textboxes for the extra players.

If you want to fill out a bracket for a game other than Melee, select a different entry in the **Game** combobox. Only Melee, Wii U, and 64 are supported.
