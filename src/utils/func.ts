export  function triggerEvent( elem: any, event: any ) {
    var clickEvent = new Event( event ); // Create the event.
    elem.dispatchEvent( clickEvent );    // Dispatch the event.
  }