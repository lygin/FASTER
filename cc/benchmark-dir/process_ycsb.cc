#include <cstdio>
#include <fstream>
#include <iostream>
#include <stdlib.h>
#include <string>

#include <sys/types.h>
#include <sys/stat.h>
#include <fcntl.h>
#include <random>
const int N = 10000000;

int main(int argc, char* argv[]) {
  std::ofstream to_file{ "load.txt" };

  const std::string prefix{ "usertable user" };
  std::mt19937_64 generator_;
  std::uniform_int_distribution<uint64_t> dist_(0,N);
  for(int i=0; i<N; ++i) {
    uint64_t key = dist_(generator_);

    to_file.write(reinterpret_cast<char*>(&key), sizeof(key));
  }
}
