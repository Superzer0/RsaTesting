// See https://aka.ms/new-console-template for more information

using ConsoleApp1;


Console.WriteLine("");

var rsaPublicKeyPkcs1 =
    "MIIBCgKCAQEAx2fQatW9pxi0rM3nJYZ1BQB5WOVppsiR8ivcT9MChxM4V1KijYMn2xAZ/6UhRu/m2HKkJjVAVofmzbLlGvIVjd2lNAyMTV7srR1eQ+kwM+kXBeW5exAoB7k/KttKMkk4Gi7rMSxOxHbV44SQS+10LzgEhJ6sAbihrXzbplTLrW+bkp1Mkl1UB+NnHCwe3af+PZvUOQrrI4MyrBsUtvH3OBVaCy16D4BjWBeUF3MZa002vPRZR2JpJpSCmkNTsykYFFJKqE3m+rQgLtDzwP+qvVqS7Ds5mNypgWEuTzdPSyZJGlsC0JFxRwjhtNbcpA49dQ8H50cRCH1butN22oVTLQIDAQAB";

var rsaPublicKeyPkcs1WithLineBreaks = @"MIIBCgKCAQEAx2fQatW9pxi0rM3nJYZ1BQB5WOVppsiR8ivcT9MChxM4V1KijYMn2xAZ/6UhRu/m
2HKkJjVAVofmzbLlGvIVjd2lNAyMTV7srR1eQ+kwM+kXBeW5exAoB7k/KttKMkk4Gi7rMSxOxHbV
44SQS+10LzgEhJ6sAbihrXzbplTLrW+bkp1Mkl1UB+NnHCwe3af+PZvUOQrrI4MyrBsUtvH3OBVa
Cy16D4BjWBeUF3MZa002vPRZR2JpJpSCmkNTsykYFFJKqE3m+rQgLtDzwP+qvVqS7Ds5mNypgWEu
TzdPSyZJGlsC0JFxRwjhtNbcpA49dQ8H50cRCH1butN22oVTLQIDAQAB";

var rsaPublicKeyPem = @"-----BEGIN RSA PUBLIC KEY-----
MIIBCgKCAQEAx2fQatW9pxi0rM3nJYZ1BQB5WOVppsiR8ivcT9MChxM4V1KijYMn2xAZ/6UhRu/m
2HKkJjVAVofmzbLlGvIVjd2lNAyMTV7srR1eQ+kwM+kXBeW5exAoB7k/KttKMkk4Gi7rMSxOxHbV
44SQS+10LzgEhJ6sAbihrXzbplTLrW+bkp1Mkl1UB+NnHCwe3af+PZvUOQrrI4MyrBsUtvH3OBVa
Cy16D4BjWBeUF3MZa002vPRZR2JpJpSCmkNTsykYFFJKqE3m+rQgLtDzwP+qvVqS7Ds5mNypgWEu
TzdPSyZJGlsC0JFxRwjhtNbcpA49dQ8H50cRCH1butN22oVTLQIDAQAB
-----END RSA PUBLIC KEY-----";

// rsaPublicKey and rsaPublicKey are the same (line breaks are allowed) but PEM header is not allowed -----END RSA PUBLIC KEY-----

var pubPemFormat = @"-----BEGIN PUBLIC KEY-----
MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAx2fQatW9pxi0rM3nJYZ1BQB5WOVppsiR
8ivcT9MChxM4V1KijYMn2xAZ/6UhRu/m2HKkJjVAVofmzbLlGvIVjd2lNAyMTV7srR1eQ+kwM+kX
BeW5exAoB7k/KttKMkk4Gi7rMSxOxHbV44SQS+10LzgEhJ6sAbihrXzbplTLrW+bkp1Mkl1UB+Nn
HCwe3af+PZvUOQrrI4MyrBsUtvH3OBVaCy16D4BjWBeUF3MZa002vPRZR2JpJpSCmkNTsykYFFJK
qE3m+rQgLtDzwP+qvVqS7Ds5mNypgWEuTzdPSyZJGlsC0JFxRwjhtNbcpA49dQ8H50cRCH1butN2
2oVTLQIDAQAB
-----END PUBLIC KEY-----";

ConvertRsa.WriteToConsole(rsaPublicKeyPkcs1, ConvertRsa.FromPublicPkcs1ToPkcs8Pem);
ConvertRsa.WriteToConsole(rsaPublicKeyPem, ConvertRsa.FromPublicPemToPkcs8Pem);
