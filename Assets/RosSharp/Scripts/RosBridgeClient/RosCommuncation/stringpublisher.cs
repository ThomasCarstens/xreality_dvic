using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RosSharp.RosBridgeClient
{
    public class stringpublisher : UnityPublisher<MessageTypes.Std.String>
    {
        public string messageData;

        public GameObject controller;


        private MessageTypes.Std.String message;

        protected override void Start()
        {
            base.Start();
            InitializeMessage();
            EventController detectCopy = controller.GetComponent<EventController>();
            messageData = detectCopy.state;
        }

        private void InitializeMessage()
        {
            message = new MessageTypes.Std.String();
            message.data = messageData;
        }

        private void Update()
        {
            EventController detectCopy = controller.GetComponent<EventController>();
            messageData = detectCopy.state;
            message.data = messageData;
            Publish(message);
        }
    }
}

