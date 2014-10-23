WowPriceSync
============

An Auction Data analyzer and sync tool for World of Warcraft. Uses Battle.net API.

Setup
  1. Create WOW database using scripts in the WoWPriceSyncUI\SQL Scripts folder. Note: I've only tested on SQL Server 2014, but the scripts should work on the lower versions with no to minimal changes required.
  2. Edit app.config to point to your database.
  3. Create an API Key on http://dev.battle.net, if you don't have one. Put this API Key in the app.config.
  4. If you have the item icons, place them in a folder and edit the app.config to point to this folder. Note: The application can sync these icons to the database to speed up launch times by an order of magnitude. To do this, turn on the DoIconSync flag in the app.config.
  5. Set realm and region info. This is used to determine which realm/region to pull data from. At the time being this is done in the code, in the main form's Load event.
  
Features
  1. Syncs Auction House Data. Snapshots are taken approximately every hour. The application checks for new data every 5 minutes.
  2. Syncs Item information. If an item is posted on the auction house that the application hasn't seen, it'll pull the item's info from the API.
  3. Data cleanup. The application removes auctions with duplicate ids. (This happens when we see an auction again because it hasn't sold.) This will eventually happen before they are written to the database.
  4. Minimum Buyout Graph. Interactive, zoomable, pannable, graphs.
  5. N-Sample Exponential Moving Average.
  6. N-Sample Simple Moving Average.
  7. Top Farmers Bar Chart. Shows the top 10 farmers for a specific item.
  8. Per-item data-provider settings for graphs.
  9. Realm status checker. If the realm is up it checks every 60 seconds. If the realm is down it checks every 2 seconds.
  10. An Alert for when the realm comes back online.
  11. Filterable list of all items found on the auction house, with icons (if you provide them).
  12. Graph of auction house volume/time for a given item.
