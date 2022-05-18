// make sure to add the following 2 lines to your Cargo.toml file:
// [dependencies]
// reqwest = "0.11"
// tokio = { version = "1", features = ["full"] }

#[tokio::main]
async fn main() -> Result<(), Box<dyn std::error::Error>>  {
    let client = reqwest::Client::builder()
        .proxy(reqwest::Proxy::https("http://unmetered.residential.proxyrack.net:9000")?
            .basic_auth("YOURUSERNAME", "YOURPASSWORD"))
        .build()?;

    let response = client.get("https://ipinfo.io").send().await?.text().await?;
    println!("{:?}", response);
    Ok(())
}