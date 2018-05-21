#!/usr/bin/env perl

use LWP::Simple qw( $ua get );

my $username = 'YOURUSERNAME';
my $password = 'YOURPASSWORD';

my $PROXY_RACK_DNS = 'megaproxy.rotating.proxyrack.net:222';

my $urlToGet = 'http://ip-api.com/json';

$ua->proxy('http', sprintf('http://%s:%s@%s', $username, $password, $PROXY_RACK_DNS));

my $contents = get($urlToGet);
print "Response:\n$contents"
