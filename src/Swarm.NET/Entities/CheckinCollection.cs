using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

namespace SwarmDotNET.Entities
{
    [JsonObject]
    public class CheckinCollection : IEnumerable<Checkin>
    {
        // 公開プロパティ

        [JsonIgnore]
        public Checkin this[int index]
        {
            get => this.Items[index];
        }

        [JsonProperty(PropertyName = "count")]
        public int Count
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "items")]
        public Checkin[] Items
        {
            get;
            set;
        }


        // 公開メソッド

        public IEnumerator<Checkin> GetEnumerator()
        {
            return ((IEnumerable<Checkin>)Items).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Items.GetEnumerator();
        }
    }
}
