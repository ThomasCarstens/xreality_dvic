/*
© Siemens AG, 2017-2018
Author: Dr. Martin Bischoff (martin.bischoff@siemens.com)

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at
<http://www.apache.org/licenses/LICENSE-2.0>.
Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

using UnityEngine;

namespace RosSharp.RosBridgeClient
{
    public class TF2Subscriber : UnitySubscriber<MessageTypes.Tf2.TFMessage>
    {
        public int scale = 1;
        public Transform PublishedTransform;
        public string desiredheader = "cfx";
        private string header = "None";
        private Vector3 position;
        private Quaternion rotation;
        private bool isMessageReceived;

        protected override void Start()
        {
            base.Start();
        }

        private void Update()
        {
            if (isMessageReceived)
                ProcessMessage();
        }

        protected override void ReceiveMessage(MessageTypes.Tf2.TFMessage message)
        {
            header = message.transforms[0].child_frame_id;
            if (header == desiredheader)
            {
                position = GetPosition(message).Ros2Unity();
                rotation = GetRotation(message).Ros2Unity();
                isMessageReceived = true;
            }
            else {
                isMessageReceived = false;
            }
        }

        private void ProcessMessage()
        {
            PublishedTransform.position = position;
            PublishedTransform.rotation = rotation;
        }

        private Vector3 GetPosition(MessageTypes.Tf2.TFMessage message)
        {
            return new Vector3(
                (float)message.transforms[0].transform.translation.y*scale,
                (float)message.transforms[0].transform.translation.x*(-1) * scale,
                (float)message.transforms[0].transform.translation.z * scale);
        }

        private Quaternion GetRotation(MessageTypes.Tf2.TFMessage message)
        {
            return new Quaternion(
                (float)message.transforms[0].transform.rotation.y,
                (float)message.transforms[0].transform.rotation.x*(-1),
                (float)message.transforms[0].transform.rotation.z,
                (float)message.transforms[0].transform.rotation.w);
        }
    }
}