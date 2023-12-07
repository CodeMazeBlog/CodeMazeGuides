using System.Collections;

namespace Tests;

public class JwtTestData : IEnumerable<object[]>
{
    private readonly List<object[]> _testTokens = new()
    {
        new object[]
        {
            "eyJhbGciOiJSUzI1NiIsImtpZCI6IjlBNkIyOTEwRDYyQ0UwMzc5RjNCREI1MjBBNTc1RTIyIiwidHlwIjoiYXQrand0In0.eyJpc3MiOiJodHRwczovL2RlbW8uZHVlbmRlc29mdHdhcmUuY29tIiwibmJmIjoxNzAwNjU0MjQ0LCJpYXQiOjE3MDA2NTQyNDQsImV4cCI6MTcwMDY1Nzg0NCwiYXVkIjoiYXBpIiwic2NvcGUiOlsiYXBpIl0sImNsaWVudF9pZCI6Im0ybSIsImp0aSI6IkUwRjYyQTA1MjM1RDY4MzdFNjcwNzExRTY1NDFDMjlEIn0.pFpzXr3jMKBYpB1JC6bq04xMyJ5gsWCq45TjO2SH44Ai6Fnic-5hn_IAYGaRPTu8dqwZjH0aBZd2UEmpvQs3WgWUANHbqG7fOAmaQQ7z3T8RRBWj5kpD6tlXmsACJAVZZl4Yra8cvrf0gacC9UHQtX9WRF51y7NeG2ZWIPq5OB4jzKvObDmcoujQgjaRRX-j7pMcpAWGxG_VMjVR9kqeOlhsfOeg3K8STIsZ46XvPhTD5CtK9j5HyYWCpadFGlpmskT8E_lBwrCGdJQae8EEO7-NllRLLaTTqz52KsT-Mhyolu7MMZy1lm58NXhv4g5_rzLbKelTWnbsBJzu-phdkg"
        },
        new object[]
        {
            "eyJhbGciOiJSUzI1NiIsImtpZCI6IjlBNkIyOTEwRDYyQ0UwMzc5RjNCREI1MjBBNTc1RTIyIiwidHlwIjoiYXQrand0In0.eyJpc3MiOiJodHRwczovL2RlbW8uZHVlbmRlc29mdHdhcmUuY29tIiwibmJmIjoxNzAwNjU1MjEwLCJpYXQiOjE3MDA2NTUyMTAsImV4cCI6MTcwMDY1ODgxMCwiYXVkIjoiYXBpIiwic2NvcGUiOlsiYXBpIl0sImNsaWVudF9pZCI6Im0ybSIsImp0aSI6IjZGQkNGNjkxNTQxMTA4MEE0Q0RCREE4OUFEQzBDMDc4In0.jNkWrgOVtByxwWmKeTvBkJXy_wopyX6uvs_oJy6D_n41ZqV_ns4LBH8jA09a_xA1D6j1mW55wmZOMhX4lRPCRCwr9IDhhrUfXu6hJt2cuxLd2UzJmcSUVoNlOvtuwMO94Dphd-HmbMGoHhUfAPe8hJ21XTddDfBq6tkyw53aBTw4Az4eUxVNifDvkmReJ7sM02koxQ6XD9gnzV4a6EHnfYEUR6RrJ9hzWL9j8yarJwH07rjC3Rg2rSF79pzmFZjNMHzJ8_CjVO1INfzJCiYGFcPglIh9SklBRwdaG78osHG6ixpu-3_-tXbnq6hBZlQcyCmxDLztj0YTrjU6u5x0IA"
        }
    };

    public IEnumerator<object[]> GetEnumerator()
    {
        return _testTokens.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}