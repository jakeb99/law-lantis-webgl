mergeInto(LibraryManager.library, {
  SendMessageToReact: function(message) {
    var messageString = UTF8ToString(message);
    window.parent.postMessage(messageString, '*');
  },
  
  InitializeReactListener: function() {
    window.addEventListener('message', function(event) {
      if (event.data && typeof event.data === 'string') {
        SendMessage('JavascriptHook', 'ReceiveFromReact', event.data);
      }
    });
  }
});