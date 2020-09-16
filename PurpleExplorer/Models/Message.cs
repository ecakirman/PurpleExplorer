using System;
using System.Text;
using Microsoft.Azure.ServiceBus;
using AzureMessage = Microsoft.Azure.ServiceBus.Message;

namespace PurpleExplorer.Models
{
    public class Message
    {
        public string MessageId { get; set; }
        public string ContentType { get; set; }
        public string Content { get; set; }
        public long Size { get; set; }
        public string CorrelationId { get; set; }
        public int DeliveryCount { get; set; }
        public long SequenceNumber { get; set; }
        public TimeSpan TimeToLive { get; set; }

        public Message(AzureMessage azureMessage)
        {
            this.Content = Encoding.UTF8.GetString(azureMessage.Body);
            this.MessageId = azureMessage.MessageId;
            this.CorrelationId = azureMessage.CorrelationId;
            this.DeliveryCount = azureMessage.SystemProperties.DeliveryCount;
            this.ContentType = azureMessage.ContentType;
            this.SequenceNumber = azureMessage.SystemProperties.SequenceNumber;
            this.Size = azureMessage.Size;
            this.TimeToLive = azureMessage.TimeToLive;
        }
    }
}