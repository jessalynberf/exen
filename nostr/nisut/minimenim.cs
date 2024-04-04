public class example
{
    private string _token;
    private string _proxy;

    public example(string token, string proxy)
    {
        if (string.IsNullOrWhiteSpace(token))
        {
            throw new ArgumentException("Token cannot be null or whitespace.", nameof(token));
        }

        if (string.IsNullOrWhiteSpace(proxy))
        {
            throw new ArgumentException("Proxy cannot be null or whitespace.", nameof(proxy));
        }

        _token = token;
        _proxy = proxy;

        // Initialize the connection with the token and proxy
        InitializeConnection();
    }

    private void InitializeConnection()
    {
        // Assuming there's a method to initialize the connection
        // This is where you'd use the _token and _proxy to set up the connection
        // For example:
        // SetupProxy(_proxy);
        // AuthenticateToken(_token);
    }

    // Placeholder methods for setting up proxy and authentication
    private void SetupProxy(string proxy)
    {
        // Implementation for setting up a proxy
    }

    private void AuthenticateToken(string token)
    {
        // Implementation for token authentication
    }
}
