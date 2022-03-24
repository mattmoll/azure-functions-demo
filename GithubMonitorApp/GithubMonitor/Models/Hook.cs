﻿using System;

public class Hook
{
    public string type { get; set; }
    public int id { get; set; }
    public string name { get; set; }
    public bool active { get; set; }
    public string[] events { get; set; }
    public Config config { get; set; }
    public string url { get; set; }
    public string test_url { get; set; }
    public string ping_url { get; set; }
    public string deliveries_url { get; set; }
    public Last_Response last_response { get; set; }
}

