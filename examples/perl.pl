#!/usr/bin/env perl

use LWP::Simple qw( $ua get );

my $username = 'YOURUSERNAME';
my $password = 'YOURPASSWORD';

my $PROXY_RACK_DNS = 'unmetered.residential.proxyrack.net:9000';

my $urlToGet = 'http://ipinfo.io';

$ua->proxy('http', sprintf('http://%s:%s@%s', $username, $password, $PROXY_RACK_DNS));

my $contents = get($urlToGet);
print "Response:\n$contents"
