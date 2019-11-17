protobuf-net\protoc.exe network.proto --java_out=Server\src\

protobuf-net\ProtoGen\protogen.exe -i:network.proto -o:Client\network.cs

"c:\\Program Files (x86)\\Mono-2.10.9\\lib\\mono\\2.0\\gmcs.exe" -t:library -r:Client\protobuf-net.dll Client\network.cs

protobuf-net\Precompile\precompile.exe Client\network.dll -o:Client\networkSerializer.dll -t:NetworkSerializer

copy Client\network.dll Client\Assets\Scripts\
copy Client\networkSerializer.dll Client\Assets\Scripts\